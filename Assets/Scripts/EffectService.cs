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
        private EffectController shellExplosion, tankExplosion;

        public EffectController CreateEffect(EffectType type)
        {
            EffectController createdEffect = null;
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
