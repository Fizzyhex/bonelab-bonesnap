using System.Reflection;
using BoneSnap;
using MelonLoader;

[assembly: AssemblyTitle(BoneSnap.Main.Description)]
[assembly: AssemblyDescription(BoneSnap.Main.Description)]
[assembly: AssemblyCompany(BoneSnap.Main.Company)]
[assembly: AssemblyProduct(BoneSnap.Main.Name)]
[assembly: AssemblyCopyright("Developed by " + BoneSnap.Main.Author)]
[assembly: AssemblyTrademark(BoneSnap.Main.Company)]
[assembly: AssemblyVersion(BoneSnap.Main.Version)]
[assembly: AssemblyFileVersion(BoneSnap.Main.Version)]
[assembly: MelonInfo(typeof(BoneSnap.Main), BoneSnap.Main.Name, BoneSnap.Main.Version, BoneSnap.Main.Author, BoneSnap.Main.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.White)]

// Create and Setup a MelonGame Attribute to mark a Melon as Universal or Compatible with specific Games.
// If no MelonGame Attribute is found or any of the Values for any MelonGame Attribute on the Melon is null or empty it will be assumed the Melon is Universal.
// Values for MelonGame Attribute can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonGame("Stress Level Zero", "BONELAB")]