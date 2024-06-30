using MelonLoader;
using BoneLib.BoneMenu;
using UnityEngine;

namespace BoneSnap
{
    internal partial class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            var melonPreferencesCategory = MelonPreferences.CreateCategory("BoneSnap");
            var boneSnapPreferences = new BoneSnapPreferences(melonPreferencesCategory);
            var boneMenuCategory = MenuManager.CreateCategory("BoneSnap", Color.white);
            BoneMenu.CreateBoneMenu(boneSnapPreferences, boneMenuCategory);
            AssetManager.Initialize();
            base.OnInitializeMelon();
        }
    }
}
