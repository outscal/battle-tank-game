using BattleTank.Enum;
using BattleTank.GenericSingleton;
using System.Collections;
using UnityEngine;

namespace BattleTank.Services
{
    public class ParticleEffectsService : GenericSingleton<ParticleEffectsService>
    {
        [SerializeField] private ParticleSystem tankExplosionEffect;
        [SerializeField] private float tankExplosionEffectDuration;
        [SerializeField] private ParticleSystem shellExplosionEffect;
        [SerializeField] private float shellExplosionEffectDuration;
        
        public void ShowExplosionEffect(ExplosionType explosionType, Vector3 spawnPosition)
        {
            ParticleSystem explosion = null;
            float effectDuration = 0f;

            if(explosionType == ExplosionType.TankExplosion)
            {
                explosion = Instantiate(tankExplosionEffect, spawnPosition, Quaternion.identity);
                effectDuration = tankExplosionEffectDuration;
            }
            else if(explosionType == ExplosionType.BulletExplosion)
            {
                explosion = Instantiate(shellExplosionEffect, spawnPosition, Quaternion.identity);
                effectDuration = shellExplosionEffectDuration;
            }
            explosion.Play();
            StartCoroutine(DestroyEffect(explosion, effectDuration));
        }
        
        IEnumerator DestroyEffect(ParticleSystem explosion, float effectDuration)
        {
            yield return new WaitForSeconds(effectDuration);
            
            Destroy(explosion.gameObject);
        }
    }
}