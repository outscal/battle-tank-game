using EnemyTankServices;
using GlobalServices;
using UnityEngine;

namespace VFXServices
{
    public class VFXHandler : MonoSingletonGeneric<VFXHandler>
    {
        [SerializeField] private GameObject explosionEffectPrefab; // Explosion effect particle system prefab.
        [SerializeField] private AudioSource explosionSound;

        public void DestroyAllGameObjects()
        {
            DestroyEnemyObjects();
            DestroyGroundObjects();
        }

        // Destroys all game objects with tag of "EnemyTank".
        private async void DestroyEnemyObjects()
        {
            // Adds some delay.
            await new WaitForSeconds(1.4f);

            // Stores reference of all objects with tag of "EnemyTank" inside array.
            GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyTank");

            for (int i = 0; i < enemyObjects.Length; i++)
            {
                enemyObjects[i].GetComponent<EnemyTankView>().tankController.Death();
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

        // Plays explosion sound effect for certain number of times.
        async private void PlayExplosionSoundEffect()
        {
            int soundPlayCount = 6;
            while(soundPlayCount > 0)
            {
                explosionSound.Play();
                soundPlayCount--;
                await new WaitForSeconds(0.4f);
            }
        }
    }

}
