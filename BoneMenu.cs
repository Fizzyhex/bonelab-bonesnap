using BoneLib.BoneMenu.Elements;
using System.Windows.Forms;
using MelonLoader;
using UnityEngine;

namespace BoneSnap
{
    internal class BoneMenu
    {
        // i wanted to implement discord webhook integration, but i havent been able to get it working :(
        // if anyone has any ideas feel free to contribute
        private static readonly bool _enableDiscordIntegration = false;

        private static void DiscordCallback(byte[] imageData)
        {
            BoneSnap.DiscordWebhook.UploadImage(BoneSnap.Preferences.currentDiscordWebhook.Value, imageData);
        }

        public static void CreateBoneMenu(MenuCategory rootCategory)
        {
            rootCategory.CreateFunctionElement(
                "Screenshot Window",
                Color.white,
                () => MelonCoroutines.Start(Screenshotter.CoPrepareScreenshot(
                    BoneSnap.Preferences.captureDelay.Value,
                    BoneSnap.Preferences.captureQuality.Value,
                    BoneSnap.Preferences.outputPath.Value
                ))
            );

            if (_enableDiscordIntegration)
            {
                rootCategory.CreateFunctionElement(
                    "Screenshot to Discord",
                    Color.white,
                    () => MelonCoroutines.Start(Screenshotter.CoPrepareScreenshot(
                        BoneSnap.Preferences.captureDelay.Value,
                        BoneSnap.Preferences.captureQuality.Value,
                        BoneSnap.Preferences.outputPath.Value,
                        DiscordCallback
                    ))
                );
            }

            rootCategory.CreateIntElement("Capture Delay", Color.white, BoneSnap.Preferences.captureDelay.Value, 1, 0, 60, delegate (int delay)
            {
                BoneSnap.Preferences.captureDelay.Value = delay;
                BoneSnap.Preferences.ManualSave();
            });

            rootCategory.CreateIntElement("Capture Quality", Color.white, BoneSnap.Preferences.captureQuality.Value, 5, 5, 100, delegate (int quality)
            {
                BoneSnap.Preferences.captureQuality.Value = quality;
                BoneSnap.Preferences.ManualSave();
            });

            rootCategory.CreateFunctionElement($@"Outputting to clipboard & {BoneSnap.Preferences.outputPath.Value}", Color.cyan, null);

            if (_enableDiscordIntegration)
            {
                var currentWebhook = BoneSnap.Preferences.currentDiscordWebhook.Value;
                rootCategory.CreateFunctionElement(string.IsNullOrWhiteSpace(currentWebhook) ? "No webhook" : $"Webhook: {currentWebhook}", Color.cyan, null);
                rootCategory.CreateFunctionElement("Paste Webhook", Color.white, delegate ()
                {
                    BoneSnap.Preferences.currentDiscordWebhook.Value = Clipboard.GetText();
                    BoneSnap.Preferences.ManualSave();
                });
            }
        }
    }
}
