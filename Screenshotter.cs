using MelonLoader;
using System.Collections;
using System.IO;
using System.Drawing;
using DateTime = System.DateTime;
using System.Windows.Forms;
using UnityEngine;

namespace BoneSnap
{
    internal static class Screenshotter
    {
        private static readonly string _userDataPath = MelonUtils.UserDataDirectory;
        private static readonly string _audioPath = $"{_userDataPath}/BoneSnap/Audio";
        private static int _screenshotIndex = 0;
        public delegate void ScreenshotCallback(byte[] image);

        private static string GenerateTimecode(DateTime time)
        {
            string datestamp = time.ToString("yyyy-MM-dd");
            string timestamp = time.ToString("HH.mm.ss");

            return datestamp + " " + timestamp;
        }

        private static byte[] TakeScreenshot(string outputPath, int quality=100)
        {
            MelonLogger.Msg("Preparing screenshot");
            string format = (quality == 100) ? "png" : "jpg";

            // Capture the entire screen
            int width = UnityEngine.Screen.width;
            int height = UnityEngine.Screen.height;
            Texture2D screenshotTexture = new Texture2D(width, height);

            // Read screen contents into the texture
            screenshotTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenshotTexture.Apply();

            // Encode texture into PNG
            byte[] bytes = (format == "png") ? ImageConversion.EncodeToPNG(screenshotTexture) : ImageConversion.EncodeToJPG(screenshotTexture, quality: quality);
            UnityEngine.Object.Destroy(screenshotTexture);

            // Output to file
            _screenshotIndex++;
            Directory.CreateDirectory(outputPath);
            string timecode = GenerateTimecode(DateTime.Now);
            string filePath = outputPath + $"/{timecode} {_screenshotIndex}.{format}";
            File.WriteAllBytes(filePath, bytes);
            Clipboard.SetImage(
                (Bitmap)((new ImageConverter()).ConvertFrom(bytes))
            );
            
            MelonLogger.Msg($"Screenshot saved as {filePath}!");

            return bytes;
        }

        public static IEnumerator CoPrepareScreenshot(float waitTime, int quality, string outputPath, ScreenshotCallback callback = null)
        {
            AudioManager.Play(AssetManager.captureTimerAudio);
            float timeWaited = 0;

            while (timeWaited < waitTime)
            {
                timeWaited += Time.deltaTime;
                yield return null;
            }

            AudioManager.Play(AssetManager.captureStartAudio);
            byte[] bytes = TakeScreenshot(outputPath, quality);
            AudioManager.Play(AssetManager.captureCompleteAudio);

            if (!(callback is null))
            {
                callback(bytes);
            }
        }
    }
}
