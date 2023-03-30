using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace BattleTank
{
    [RequireComponent(typeof(Rigidbody), typeof(NavMeshAgent))]
    public class EnemyTankView : MonoBehaviour, IDamageable
    {
        private EnemyTankController enemyTankController;
        [SerializeField] private List<MeshRenderer> tankBody;
        private Rigidbody rb;
        private NavMeshAgent agent;
        private float nextShootTime;
        [SerializeField] private Transform bulletTransform;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            enemyTankController.UpdateTankColor(tankBody);
            nextShootTime = 0;
        }

        private void Update()
        {
            if(enemyTankController.GetCurrentHealth() <= 0)
            {
                DestroyGameObject();
            }

            agent.SetDestination(enemyTankController.GetPlayerTank().position);

            if (agent.velocity.magnitude == 0 && agent.remainingDistance < agent.stoppingDistance)
            {
                if(Time.time > nextShootTime)
                {
                    nextShootTime = Time.time + 2.5f / enemyTankController.GetFireRate();
                    enemyTankController.SpawnBullet(bulletTransform, this.transform.rotation);
                }
            }
        }

        public void SetEnemyTankController(EnemyTankController _enemyTankController)
        {
            enemyTankController = _enemyTankController;
        }

        public void Damage(float damage)
        {
            Debug.Log("EnemyTankView Damage");
            enemyTankController.TakeDamage(damage);
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}