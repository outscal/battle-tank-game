using BattleTank.Enum;
using BattleTank.GenericSingleton;
using BattleTank.Services.ObjectPoolService;
using System.Collections;
using UnityEngine;

namespace BattleTank.Services
{
    public class ParticleEffectsService : GenericSingleton<ParticleEffectsService>
    {
        [SerializeField] private float tankExplosionEffectDuration;
        [SerializeField] private float shellExplosionEffectDuration;

        [SerializeField] private BulletParticlePoolService bulletParticlePoolService;
        [SerializeField] private TankParticlePoolService tankParticlePoolService;
        
        public void ShowExplosionEffect(ExplosionType explosionType, Vector3 spawnPosition)
        {
            ParticleSystem explosion = null;
            float effectDuration = 0f;

            if(explosionType == ExplosionType.TankExplosion)
            {
                explosion = tankParticlePoolService.GetItem(ObjectPoolType.TankParticlePool);
                effectDuration = tankExplosionEffectDuration;
            }
            else if(explosionType == ExplosionType.BulletExplosion)
            {
                explosion = bulletParticlePoolService.GetItem(ObjectPoolType.BulletParticlePool);
                effectDuration = shellExplosionEffectDuration;
            }
            explosion.transform.position = spawnPosition;
            explosion.gameObject.SetActive(true);
            explosion.Play();
            StartCoroutine(DestroyEffect(explosionType, explosion, effectDuration));
        }
        
        IEnumerator DestroyEffect(ExplosionType explosionType, ParticleSystem explosion, float effectDuration)
        {
            yield return new WaitForSeconds(effectDuration);
            
            if(explosionType == ExplosionType.TankExplosion)
            {
                tankParticlePoolService.ReturnItem(ObjectPoolType.TankParticlePool, explosion);
            }
            if(explosionType == ExplosionType.BulletExplosion)
            {
                bulletParticlePoolService.ReturnItem(ObjectPoolType.BulletParticlePool, explosion);
            }
        }
    }
}