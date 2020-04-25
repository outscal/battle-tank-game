using System.Collections.Generic;
using UnityEngine;
using Generic;


namespace Singalton
{
    public class SoundManager : MonoSingletonGeneric<SoundManager>
    {
        public AudioSource AudioSource;
        public List<SoundClips> SoundClips = new List<SoundClips>();

        protected override void Awake()
        {
            base.Awake();
        }


        public void PlaySoundClip(ClipName clipName)
        {
            for (int i = 0; i < SoundClips.Count; i++)
            {
                if(SoundClips[i].Name == clipName)
                {
                    AudioSource.PlayOneShot(SoundClips[i].Clip);
                }
            }
        }
    }
}
