using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

namespace Interfaces
{
    public interface IAudio : IService
    {
        void PlayAudio(AudioName audioName);
        void StopFXAudio();
        void StopBackground();
        void PlayAudioOneShot(AudioName audioName);
    }
}