using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Outscal.BattleTank
{
    /// <summary>
    /// creating enemy tank view
    /// </summary>
    public class EnemyTankView : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        public EnemyTankController enemyTankController;
        private float maxZ, maxX, minZ, minX;
        public Transform bulletShootPoint;
        private float patrollTime;
        private float howClose;
        private float timer;
        private float canFire=0f;
        private BoxCollider ground;
        public MeshRenderer[] childs;
      
        private void Awake()
        {
            navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            ground = GroundBoxCollider.groundBoxCollider;
            maxX = ground.bounds.max.x;
            maxZ = ground.bounds.max.z;
            minX = ground.bounds.min.x;
            minZ = ground.bounds.min.z;
            timer = 0;
            patrollTime = 5f;
            howClose = 20f;
            Invoke("Patrol", 1f);           
        }

        private void Update()
        {
            if (TankService.Instance.PlayerPos() != null)
            {
                float distance = Vector3.Distance(TankService.Instance.PlayerPos().position, transform.position);
                if (distance <= howClose)
                {
                    transform.LookAt(TankService.Instance.PlayerPos());
                    navMeshAgent.SetDestination(TankService.Instance.PlayerPos().position);
                    ShootBullet();
                }
                else
                {
                    Patrol();
                }
            }
            else
            {
                Patrol();
            }
        }

        public void SetEnemyTankController(EnemyTankController _enemyTankController) 
        {
            enemyTankController = _enemyTankController;
        }

        public Vector3 GetRandomPosition()
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 randomDir = new Vector3(x, 0, z);
            return randomDir;
        }

        public void SetPatrollingDestination()
        {        
            Vector3 newDestnation = GetRandomPosition();
            navMeshAgent.SetDestination(newDestnation);
        }

        public void Patrol()
        {
            timer += Time.deltaTime;
            if (timer > patrollTime)
            {
                SetPatrollingDestination();
                timer = 0;
            }
        }

        private void ShootBullet()
        {
            if (canFire < Time.time)
            {
                canFire = enemyTankController.EnemyTankModel.fireRate + Time.time;
                enemyTankController.ShootBullet();
            }
        }

        public void DestroyView()
        {
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
            enemyTankController = null;
            bulletShootPoint = null;
            Destroy(this.gameObject);
        }
    }
}