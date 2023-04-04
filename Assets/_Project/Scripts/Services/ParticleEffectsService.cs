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

        public void ShowTankExplosionEffect(Vector3 spawnPosition)
        {
            ParticleSystem tankExplosion = Instantiate(tankExplosionEffect, spawnPosition, Quaternion.identity);
            tankExplosion.Play();
            StartCoroutine(DestroyEffect(tankExplosion, tankExplosionEffectDuration));
        }

        public void ShowBulletExplosionEffect(Vector3 spawnPosition)
        {
            ParticleSystem bulletExplosion = Instantiate(shellExplosionEffect, spawnPosition, Quaternion.identity);
            bulletExplosion.Play();
            StartCoroutine(DestroyEffect(bulletExplosion, shellExplosionEffectDuration));
        }

        IEnumerator DestroyEffect(ParticleSystem explosionEffect, float effectDuration)
        {
            yield return new WaitForSeconds(effectDuration);
            Destroy(explosionEffect.gameObject);
        }
    }
}