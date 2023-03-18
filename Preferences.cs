using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;

namespace BoneSnap
{
    internal static class Preferences
    {
        private static MelonPreferences_Category currentCategory;
        public static MelonPreferences_Entry<int> captureDelay;
        public static MelonPreferences_Entry<int> captureQuality;
        public static MelonPreferences_Entry<string> currentDiscordWebhook;

        public static void CreateMelonPreferences(MelonPreferences_Category category)
        {
            currentCategory = category;
            captureDelay = category.CreateEntry<int>("CaptureDelay", 3);
            captureQuality = category.CreateEntry<int>("CaptureQuality", 100);
            currentDiscordWebhook = category.CreateEntry<string>("CurrentDiscordWebhook", "");
        }

        // Need to do this in a better way...
        public static void ManualSave()
        {
            currentCategory.SaveToFile();
        }
    }
}
