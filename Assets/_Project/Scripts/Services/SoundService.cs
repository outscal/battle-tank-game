using BattleTank.Enum;
using BattleTank.GenericSingleton;
using System;
using UnityEngine;

namespace BattleTank.Services
{
    public class SoundService : GenericSingleton<SoundService>
    {
        [SerializeField] private AudioSource SoundEffect;
        [SerializeField] private AudioSource SoundMusic;

        [SerializeField] private SoundType[] Sounds;
        
        public void PlayEffects(Sounds sound)
        {
            AudioClip clip = GetAudioClip(sound);
            if (clip != null)
            {
                SoundEffect.PlayOneShot(clip);
            }
        }

        public void PlayMusic(Sounds sound)
        {
            AudioClip clip = GetAudioClip(sound);
            if (clip != null)
            {
                SoundMusic.clip = clip;
                SoundMusic.Play();
            }
        }

        private AudioClip GetAudioClip(Sounds sound)
        {
            SoundType item = Array.Find(Sounds, i => i.soundType == sound);
            if (item != null)
            {
                return item.soundClip;
            }
            else
            {
                return null;
            }
        }
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }
}