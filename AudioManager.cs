using UnityEngine;

namespace BoneSnap
{
    internal static class AudioManager
    {
        private static GameObject audioGameObject;

        public static void Play(AudioClip clip)
        {
            audioGameObject = audioGameObject ? audioGameObject : new GameObject("BoneSnap AudioManager");
            var audioSource = audioGameObject.GetComponent<AudioSource>()
                ? audioGameObject.GetComponent<AudioSource>()
                : audioGameObject.AddComponent<AudioSource>();
            audioSource.PlayOneShot(clip, 0.7f);
        }
    }
}
