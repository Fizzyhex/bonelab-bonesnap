using UnityEngine;
using AudioImportLib;

namespace BoneSnap
{
    internal static class AudioManager
    {
        private static GameObject emptyGameObject;

        public static void Play(AudioClip clip)
        {
            emptyGameObject = emptyGameObject ? emptyGameObject : new GameObject("BoneSnap AudioManager");
            AudioSource audioSource = emptyGameObject.GetComponent<AudioSource>() ? emptyGameObject.GetComponent<AudioSource>() : emptyGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip, 0.7f);
        }
    }
}
