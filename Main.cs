using MelonLoader;
using BoneLib.BoneMenu;

using UnityEngine;

namespace BoneSnap
{
    internal partial class Main : MelonMod
    {
        private delegate void ScreenshotCallback(byte[] image);

        public override void OnInitializeMelon()
        {
            BoneSnap.Preferences.CreateMelonPreferences(MelonLoader.MelonPreferences.CreateCategory("BoneSnap"));
            BoneSnap.BoneMenu.CreateBoneMenu(MenuManager.CreateCategory("BoneSnap", Color.white));
            AssetManager.Initialize();
            base.OnInitializeMelon();
        }
    }
}
