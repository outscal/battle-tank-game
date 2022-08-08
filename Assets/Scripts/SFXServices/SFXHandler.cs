using GlobalServices;
using System;
using UnityEngine;

namespace SFXServices
{
    public class SFXHandler : MonoBehaviour
    {
        // Array that holds sound type and respective audio clip.
        public SoundType[] sounds;

        public AudioSource soundEffect; // Audio source to play sound effects.
        public AudioSource soundMusic; // Audio source to play background music.

        // Implementation of singleton design pattern.
        private static SFXHandler instance;
        public static SFXHandler Instance { get { return instance; } }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            // Play music on start.
            PlayMusic(SFXHandler.Sounds.Music);
        }

        // For background music.
        public void PlayMusic(Sounds sound)
        {
            AudioClip clip = GetSoundClip(sound);
            if (clip != null)
            {
                soundMusic.clip = clip;
                soundMusic.Play();
            }
        }

        // For sound effects.
        public void Play(Sounds sound)
        {
            AudioClip clip = GetSoundClip(sound);
            if (clip != null)
            {
                soundEffect.PlayOneShot(clip);
            }
        }

        // Returns audio clip based on sound effect selected.
        private AudioClip GetSoundClip(Sounds sound)
        {
            SoundType returnSound = Array.Find(sounds, item => item.soundType == sound);
            return returnSound.soundClip;
        }

        // Class to hold sound effect type and respective audio clip.
        [Serializable]
        public class SoundType
        {
            public Sounds soundType;
            public AudioClip soundClip;
        }

        // Enum to select sound effect.
        public enum Sounds
        {
            ButtonClick,
            SlowMotion,
            Music,
        }
    }
}
