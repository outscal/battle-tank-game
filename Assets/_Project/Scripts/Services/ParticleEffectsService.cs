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

            if(explosionType == ExplosionType.TankExplosion)
            {
                explosion = Instantiate(tankExplosionEffect, spawnPosition, Quaternion.identity);
            }
            else if(explosionType == ExplosionType.BulletExplosion)
            {
                explosion = Instantiate(shellExplosionEffect, spawnPosition, Quaternion.identity);
            }
            
            explosion.Play();
            StartCoroutine(DestroyEffect(explosion, tankExplosionEffectDuration));
        }
        
        IEnumerator DestroyEffect(ParticleSystem explosionEffect, float effectDuration)
        {
            yield return new WaitForSeconds(effectDuration);
            Destroy(explosionEffect.gameObject);
        }
    }
}