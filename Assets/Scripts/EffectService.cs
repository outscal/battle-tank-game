using UnityEngine;
using Singleton;

namespace Effects
{
    public enum EffectType : ushort
    {
        shellExplosionEffect,
        tankExposionEffect
    }

    public class EffectService : MonoSingletonGeneric<EffectService>
    {
        [SerializeField]
        private ParticleSystem shellExplosion, tankExplosion;

        public ParticleSystem CreateEffect(EffectType type)
        {
            ParticleSystem createdEffect = null;
            switch (type)
            {
                case EffectType.shellExplosionEffect:
                    createdEffect = Instantiate(shellExplosion);
                    break;
                case EffectType.tankExposionEffect:
                    createdEffect = Instantiate(tankExplosion);
                    break;
            }
            return createdEffect;

        }
    }
}
