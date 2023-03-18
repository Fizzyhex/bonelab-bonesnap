using MelonLoader;
using BoneLib.BoneMenu;
using BoneLib.BoneMenu.Elements;

using System.Collections;
using System.Threading.Tasks;
using System.IO;
using UnityEngine.Networking;
using DateTime = System.DateTime;

using UnityEngine;
using Clipboard = System.Windows.Forms.Clipboard;

namespace BoneSnap
{
    internal partial class Main : MelonMod
    {
        private static readonly string _screenshotFolder = "UserData/Screenshots";
        private delegate void ScreenshotCallback(byte[] image);

        public override void OnLateInitializeMelon()
        {
            BoneSnap.Preferences.CreateMelonPreferences(MelonLoader.MelonPreferences.CreateCategory("BoneSnap"));
            BoneSnap.BoneMenu.CreateBoneMenu(MenuManager.CreateCategory("BoneSnap", Color.white));

            Directory.CreateDirectory(_screenshotFolder);
            MelonLogger.Msg($"Created screenshot folder {_screenshotFolder}");

            base.OnLateInitializeMelon();
        }
    }
}
