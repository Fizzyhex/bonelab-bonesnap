using BoneLib.BoneMenu.Elements;
using MelonLoader;
using UnityEngine;

namespace BoneSnap
{
    internal abstract class BoneMenu
    {
        public static void CreateBoneMenu(BoneSnapPreferences preferences, MenuCategory rootCategory)
        {
            rootCategory.CreateFunctionElement(
                "Screenshot Window",
                Color.white,
                () => MelonCoroutines.Start(Screenshotter.CoPrepareScreenshot(
                    preferences.CaptureDelay.Value,
                    preferences.CaptureQuality.Value,
                    preferences.OutputPath.Value
                ))
            );
            
            rootCategory.CreateIntElement("Capture Delay", Color.white, preferences.CaptureDelay.Value, 1, 0, 60, delegate (int delay)
            {
                preferences.CaptureDelay.Value = delay;
                preferences.ManualSave();
            });

            rootCategory.CreateIntElement("Capture Quality", Color.white, preferences.CaptureQuality.Value, 5, 5, 100, delegate (int quality)
            {
                preferences.CaptureQuality.Value = quality;
                preferences.ManualSave();
            });

            rootCategory.CreateFunctionElement($@"Outputting to clipboard & {preferences.OutputPath.Value}", Color.cyan, null);
        }
    }
}
