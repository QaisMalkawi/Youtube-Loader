using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Text.RegularExpressions;
using YoutubeExplode;
using YoutubeExplode.Common;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Video_Loder
{
    public partial class Form1 : Form
    {
        bool programBusy = false;

        Video? targetVideo;
        YoutubeClient youtubeClient;
        public Form1()
        {
            InitializeComponent();
            youtubeClient = new();
            btn_download.Enabled = false;
        }

        private async void btn_fetch_Click(object sender, EventArgs e)
        {
            btn_fetch.Enabled = false;
            btn_download.Enabled = false;
            pbx_thumbnailPreview.Image = null;

            string url = tbx_urlField.Text.Trim();
            if (string.IsNullOrEmpty(url) || string.IsNullOrWhiteSpace(url) || !Regex.IsMatch(url, @"^(https?:\/\/)?(www\.)?(youtube\.com\/(watch\?v=|shorts\/|embed\/)|youtu\.be\/)([a-zA-Z0-9_-]{11})([&?][^\s]*)?$"))
            {
                btn_fetch.Enabled = true;
                return;
            }

            targetVideo = await youtubeClient.Videos.GetAsync(url);

            if (targetVideo == null)
            {
                btn_fetch.Enabled = true;
                return;
            }

            Thumbnail[] thumbnails = targetVideo.Thumbnails.OrderByDescending(t => t.Resolution.Area).ToArray();

            Image? thumbnailImage = null;
            foreach (var tn in thumbnails)
            {
                thumbnailImage = await GetImageFromURL(tn.Url);
                if (thumbnailImage != null)
                    break;
            }
            if (thumbnailImage == null)
            {
                btn_fetch.Enabled = true;
                btn_download.Enabled = targetVideo != null;
                return;
            }

            pbx_thumbnailPreview.Image = thumbnailImage;

            btn_fetch.Enabled = true;
            btn_download.Enabled = targetVideo != null;
        }


        public static async Task<Image> GetImageFromURL(string url)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    // Download the image data
                    byte[] imageData = await httpClient.GetByteArrayAsync(url);

                    // Create a MemoryStream to hold the data
                    using (MemoryStream memoryStream = new MemoryStream(imageData))
                    {
                        // Load the image from the MemoryStream
                        return Image.FromStream(memoryStream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error downloading image: {ex.Message}");
                    return null;
                }
            }
        }

        private async void btn_download_Click(object sender, EventArgs e)
        {
            if (targetVideo == null) return;

            var progress = (IProgress<double>)(new Progress<double>(p => pbr_progress.Value = ((int)(p * 100))));

            if (!Directory.Exists("Downloads/.temp"))
                Directory.CreateDirectory("Downloads/.temp");

            btn_fetch.Enabled = false;
            btn_download.Enabled = false;

            await youtubeClient.Videos.GetAsync(targetVideo.Url);

            var videoManifest = await youtubeClient.Videos.Streams.GetManifestAsync(targetVideo.Url);
            IStreamInfo videoStream = videoManifest.GetVideoOnlyStreams()
                                      .Where(v => v.Container == YoutubeExplode.Videos.Streams.Container.WebM).GetWithHighestVideoQuality();
            
            IStreamInfo audioStream = videoManifest.GetAudioOnlyStreams()
                                      .Where(a => a.Container == YoutubeExplode.Videos.Streams.Container.WebM).GetWithHighestBitrate();

            string tempVideoDir = $"Downloads/.temp/{targetVideo.Title}-tempVideo.webm";
            if (File.Exists(tempVideoDir))
                File.Delete(tempVideoDir);
            
            string tempAudioDir = $"Downloads/.temp/{targetVideo.Title}-tempAudio.webm";
            if (File.Exists(tempAudioDir))
                File.Delete(tempAudioDir);

            string outputDir = $"Downloads/{targetVideo.Title}.webm";
            if (File.Exists(outputDir))
                File.Delete(outputDir);

            await youtubeClient.Videos.Streams.DownloadAsync(videoStream, tempVideoDir, progress);
            await youtubeClient.Videos.Streams.DownloadAsync(audioStream, tempAudioDir, progress);

            await CombineVideoAndAudioWithProgress(tempVideoDir, tempAudioDir, outputDir);

            await Task.Run(() =>
            {
                if (File.Exists(tempVideoDir))
                    File.Delete(tempVideoDir);

                if (File.Exists(tempAudioDir))
                    File.Delete(tempAudioDir);
            });

            progress.Report(0);
            btn_fetch.Enabled = true;
            btn_download.Enabled = true;
        }

        public static async Task CombineVideoAndAudioWithProgress(string videoPath, string audioPath, string outputPath)
        {
            string ffmpegPath = "ffmpeg/bin/ffmpeg.exe";
            string arguments = $"-i \"{videoPath}\" -i \"{audioPath}\" -c:v copy -c:a copy -shortest -f webm \"{outputPath}\"";

            using (Process ffmpeg = new Process())
            {
                ffmpeg.StartInfo.FileName = ffmpegPath;
                ffmpeg.StartInfo.Arguments = arguments;
                ffmpeg.StartInfo.UseShellExecute = false;
                ffmpeg.StartInfo.RedirectStandardError = true;
                ffmpeg.StartInfo.RedirectStandardOutput = false;
                ffmpeg.StartInfo.CreateNoWindow = true;

                ffmpeg.Start();

                string stderrLine;
                using (StreamReader reader = ffmpeg.StandardError)
                {
                    string errorOutput = "";

                    while ((stderrLine = await reader.ReadLineAsync()) != null)
                        errorOutput += stderrLine;

                    await ffmpeg.WaitForExitAsync();
                    if (ffmpeg.ExitCode != 0)
                    {
                        throw new Exception($"FFmpeg failed with the following error:\n{errorOutput}");
                    }
                }
            }
        }
    }
}
