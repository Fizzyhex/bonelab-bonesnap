using System.IO;
using MelonLoader;

namespace BoneSnap
{
    internal static class Preferences
    {
        private static MelonPreferences_Category currentCategory;
        public static MelonPreferences_Entry<int> captureDelay;
        public static MelonPreferences_Entry<int> captureQuality;
        public static MelonPreferences_Entry<string> currentDiscordWebhook;
        public static MelonPreferences_Entry<string> outputPath;

        public static void CreateMelonPreferences(MelonPreferences_Category category)
        {
            currentCategory = category;
            captureDelay = category.CreateEntry("CaptureDelay", 4);
            captureQuality = category.CreateEntry("CaptureQuality", 95);
            currentDiscordWebhook = category.CreateEntry("CurrentDiscordWebhook", "");
            outputPath = category.CreateEntry("OutputPath", "UserData/Screenshots");
            Directory.CreateDirectory(outputPath.Value);
        }

        // May need to find a better solution...
        public static void ManualSave()
        {
            currentCategory.SaveToFile();
        }
    }
}
