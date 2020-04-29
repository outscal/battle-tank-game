using ParticleSystem.Model;
using ParticleSystem.View;
using ParticleSystem.Service;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ParticleSystem.Controller
{
    public class ParticleEffectController
    {
        public ParticleEffectView ParticleEffectView { get; }
        public ParticleEffectModel ParticleEffectModel { get; }
        public ParticleEffectController(ParticleEffectModel particleEffectModel, ParticleEffectView particleEffectView, Vector3 position)
        {
            ParticleEffectModel = particleEffectModel;
            ParticleEffectView = GameObject.Instantiate<ParticleEffectView>(particleEffectView, position, new Quaternion(0f, 0f, 0f, 0f));
            ParticleEffectView.SetParticleEffectController(this);
        }

        public void DestroyView()
        {
            ParticleEffectView.DestroyView();
        }

        //public void SetOffParticleEffect()
        //{
        //    ParticleEffectView.
        //}
    }
}