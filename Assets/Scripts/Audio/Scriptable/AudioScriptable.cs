using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

namespace BTScriptableObject
{
    [System.Serializable]
    public struct AudioData
    {
        public string name;
        public AudioName audioName;
        public AudioClip audioClip;
    }

    [CreateAssetMenu(fileName = "AudioList", menuName = "ScriptableObj/AudioList", order = 6)]
    public class AudioScriptable : ScriptableObject
    {
        public List<AudioData> audioData;
    }
}