using ParticleSystem.Controller;
using ParticleSystem.Model;
using ParticleSystem.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ParticleSystem.Service
{
    public class ParticleEffectService : MonoSingletonGeneric<ParticleEffectService>
    {
        public ParticleEffectView ParticleEffectView;
        ParticleEffectController particleEffectController;
        ParticleEffectModel particleEffectModel;

        public ParticleEffectController CreateNewEffect(Vector3 position)
        {
            particleEffectModel = new ParticleEffectModel();
            particleEffectController = new ParticleEffectController(particleEffectModel, ParticleEffectView, position);
            return particleEffectController;
        }

        public ParticleEffectController GetParticleEffect(Vector3 position)
        {
            return CreateNewEffect(position);
        }

        public void DestroyParticleEffect()
        {
            particleEffectController.DestroyView();
            particleEffectModel = null;
            particleEffectController = null;
        }
    }
}