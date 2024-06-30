using System.IO;
using MelonLoader;

namespace BoneSnap
{
    public readonly struct BoneSnapPreferences(MelonPreferences_Category category)
    {
        public readonly MelonPreferences_Entry<int> CaptureDelay = category.CreateEntry("CaptureDelay", 4);
        public readonly MelonPreferences_Entry<int> CaptureQuality = category.CreateEntry("CaptureQuality", 95);
        public readonly MelonPreferences_Entry<string> OutputPath = category.CreateEntry("OutputPath", "UserData/Screenshots");

        public void ManualSave()
        {
            category.SaveToFile();
        }
    }
}
