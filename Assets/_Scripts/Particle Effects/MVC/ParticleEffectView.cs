using System;
using System.Collections;
using System.Collections.Generic;
using ParticleSystem.Controller;
using UnityEngine;

namespace ParticleSystem.View
{
    public class ParticleEffectView : MonoBehaviour
    {
        ParticleEffectController particleEffectController;
        public void SetParticleEffectController(ParticleEffectController pEC)
        {
            particleEffectController = pEC;
        }

        public void DestroyView()
        {
            Destroy(gameObject);
        }
    }
}