using System.Collections.Generic;
using System.IO;

using MelonLoader;
using UnityEngine;
using AudioImportLib;

namespace BoneSnap
{
    internal static class AssetManager
    {
        static readonly string userDataPath = MelonUtils.UserDataDirectory;
        static readonly string modStoragePath = $"{userDataPath}/BoneSnap";
        static readonly string audioPath = $"{modStoragePath}/Audio";

        public static AudioClip captureTimerAudio;
        public static AudioClip captureCompleteAudio;
        public static AudioClip captureStartAudio;

        private static void LoadAudio()
        {
            captureStartAudio = API.LoadAudioClip($"{audioPath}/capture_start.wav", true);
            captureCompleteAudio = API.LoadAudioClip($"{audioPath}/capture_complete.wav", true);
            captureTimerAudio = API.LoadAudioClip($"{audioPath}/capture_timer.wav", true);
        }

        private static void CreateDirectories()
        {
            Directory.CreateDirectory(audioPath);
        }

        public static void Initialize()
        {
            CreateDirectories();
            LoadAudio();
        }
    }
}
