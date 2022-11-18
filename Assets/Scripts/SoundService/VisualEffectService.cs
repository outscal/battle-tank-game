using EnemyTankServices;
using GameServices;
using UnityEngine;

namespace EffectServices
{
    public class VisualEffectService : GenericSingleton<VisualEffectService>
    {
        [SerializeField] private GameObject explosionEffectPrefab; 
        [SerializeField] private AudioSource explosionSound;

        public void DestroyAllGameObjects()
        {
            DestroyEnemyObjects();
            DestroyGroundObjects();
        }

        private async void DestroyEnemyObjects()
        {
            await new WaitForSeconds(1.4f);

            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTank");

            for (int i = 0; i < enemyObjects.Length; i++)
            {
                enemyObjects[i].GetComponent<EnemyTankView>().enemyTankController.Death();
            }
        }

        // Destroys all game objects with tag of "Ground".
        private async void DestroyGroundObjects()
        {
            await new WaitForSeconds(2f);

            PlayExplosionSoundEffect();

            // Stores reference of all objects with tag of "Ground" inside array.
            GameObject[] groundObjects = GameObject.FindGameObjectsWithTag("Ground");

            for (int i = groundObjects.Length - 1; i >= 0; i--)
            {
                ParticleSystem explosionParticles = Instantiate(explosionEffectPrefab).GetComponent<ParticleSystem>();

                explosionParticles.transform.position = groundObjects[i].transform.position;
                explosionParticles.Play();

                Destroy(explosionParticles.gameObject, 1f);
                Destroy(groundObjects[i]);
                await new WaitForSeconds(0.04f);
            }
        }

        async private void PlayExplosionSoundEffect()
        {
            int soundPlayCount = 6;
            while (soundPlayCount > 0)
            {
                explosionSound.Play();
                soundPlayCount--;
                await new WaitForSeconds(0.4f);
            }
        }
    }

}
