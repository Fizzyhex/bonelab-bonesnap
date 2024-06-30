using AudioImportLib;
using MelonLoader.Utils;
using UnityEngine;

namespace BoneSnap
{
    internal static class AssetManager
    {
        private static readonly string UserDataPath = MelonEnvironment.UserDataDirectory;
        private static readonly string ModStoragePath = $"{UserDataPath}/BoneSnap";
        private static readonly string AudioPath = $"{ModStoragePath}/Audio";

        public static AudioClip? CaptureTimerAudio;
        public static AudioClip? CaptureCompleteAudio;
        public static AudioClip? CaptureStartAudio;

        private static void LoadAudio()
        {
            CaptureStartAudio = API.LoadAudioClip($"{AudioPath}/capture_start.wav", true);
            CaptureCompleteAudio = API.LoadAudioClip($"{AudioPath}/capture_complete.wav", true);
            CaptureTimerAudio = API.LoadAudioClip($"{AudioPath}/capture_timer.wav", true);
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(AudioPath);
        }

        public static void Initialize()
        {
            CreateDirectories();
            LoadAudio();
        }
    }
}
