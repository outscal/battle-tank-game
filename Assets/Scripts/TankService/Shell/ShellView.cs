using System;
using UnityEngine;

namespace TankBattle.TankService.Bullets
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShellView : MonoBehaviour
    {
        //[SerializeField] private ParticleSystem explosionParticles;
        //[SerializeField] private AudioSource explosionAudio;

        private Rigidbody rb;

        //public AudioSource GetAudioSystem()
        //{
        //    return explosionAudio;
        //}

        //public ParticleSystem GetParticleSystem()
        //{
        //    return explosionParticles;
        //}

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
    }
}
