using MelonLoader;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using UnityEngine;
using DateTime = System.DateTime;

namespace BoneSnap
{
    internal static class Screenshotter
    {
        private static int _screenshotIndex;

        private static string GenerateTimecode(DateTime time)
        {
            var datestamp = time.ToString("yyyy-MM-dd");
            var timestamp = time.ToString("HH.mm.ss");

            return datestamp + " " + timestamp;
        }

        private static void TakeScreenshot(string outputPath, int quality = 100)
        {
            MelonLogger.Msg("Preparing screenshot");
            var format = (quality == 100) ? "png" : "jpg";

            // Capture the entire screen
            var width = UnityEngine.Screen.width;
            var height = UnityEngine.Screen.height;
            var screenshotTexture = new Texture2D(width, height);

            // Read screen contents into the texture
            screenshotTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            screenshotTexture.Apply();

            // Encode texture into PNG
            byte[] bytes = (format == "png") ? screenshotTexture.EncodeToPNG() : screenshotTexture.EncodeToJPG(quality: quality);
            UnityEngine.Object.Destroy(screenshotTexture);

            // Output to file
            _screenshotIndex++;
            Directory.CreateDirectory(outputPath);
            var timecode = GenerateTimecode(DateTime.Now);
            var filePath = outputPath + $"/{timecode} {_screenshotIndex}.{format}";
            
            File.WriteAllBytes(filePath, bytes);
            Clipboard.SetImage(
                (Bitmap)((new ImageConverter()).ConvertFrom(bytes))
            );
            
            MelonLogger.Msg($"Screenshot saved as {filePath}!");
        }

        public static IEnumerator CoPrepareScreenshot(float waitTime, int quality, string outputPath)
        {
            if (AssetManager.CaptureTimerAudio != null) AudioManager.Play(AssetManager.CaptureTimerAudio);
            yield return new WaitForSeconds(waitTime);

            if (AssetManager.CaptureStartAudio != null) AudioManager.Play(AssetManager.CaptureStartAudio);
            TakeScreenshot(outputPath, quality);
            
            if (AssetManager.CaptureCompleteAudio != null) AudioManager.Play(AssetManager.CaptureCompleteAudio);
        }
    }
}
