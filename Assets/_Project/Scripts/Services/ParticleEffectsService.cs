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
        private ParticleSystem explosion;
        
        public void ShowExplosionEffect(ExplosionType explosionType, Vector3 spawnPosition)
        {
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
            StartCoroutine(DestroyEffect(explosionType, explosion, effectDuration));
        }
        
        IEnumerator DestroyEffect(ExplosionType explosionType, ParticleSystem explosionEffect, float effectDuration)
        {
            yield return new WaitForSeconds(effectDuration);

            if(explosionType == ExplosionType.TankExplosion)
            {
                Destroy(explosion);
            }
            else if(explosionType == ExplosionType.BulletExplosion)
            {
                Destroy(explosion);
            }
        }
    }
}