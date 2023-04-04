using BattleTank.Interface;
using BattleTank.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank.EnemyTank
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private EnemyTankController enemyTankController;
        [SerializeField] private List<MeshRenderer> tankRenderer;
        [SerializeField] private Rigidbody rigidBody;
        [SerializeField] private NavMeshAgent agent;
        private float nextShootTime;
        private float additionalAttackTime;
        [SerializeField] private Transform bulletTransform;

        private void Start()
        {
            enemyTankController.UpdateTankColor(tankRenderer);
            nextShootTime = 0;
            additionalAttackTime = 2.5f;
        }

        private void Update()
        {
            if (enemyTankController.GetCurrentHealth() <= 0)
            {
                DestroyGameObject();
            }

            if (agent.isActiveAndEnabled == true && enemyTankController.GetPlayerTank() != null)
            {
                agent.SetDestination(enemyTankController.GetPlayerTank().position);
            }

            if (agent.isActiveAndEnabled == true && enemyTankController.GetPlayerTank() != null)
            {
                gameObject.transform.LookAt(enemyTankController.GetPlayerTank());

                if (agent.velocity.magnitude == 0 && agent.remainingDistance < agent.stoppingDistance)
                {
                    if (Time.time > nextShootTime)
                    {
                        nextShootTime = Time.time + additionalAttackTime / enemyTankController.GetFireRate();
                        enemyTankController.SpawnBullet(bulletTransform, gameObject.transform.rotation);
                    }
                }
            }
        }

        public void SetEnemyTankController(EnemyTankController _enemyTankController)
        {
            enemyTankController = _enemyTankController;
        }

        public void Damage(float damage)
        {
            enemyTankController.TakeDamage(damage);
        }

        public void DestroyGameObject()
        {
            ParticleEffectsService.Instance.ShowTankExplosionEffect(gameObject.transform.position);
            enemyTankController.SetIsTankAlive(false);
            StartCoroutine(DestroyTank());
        }

        IEnumerator DestroyTank()
        {
            yield return new WaitForSeconds(enemyTankController.GetTankDestryTime());
            Destroy(gameObject);
        }
    }
}