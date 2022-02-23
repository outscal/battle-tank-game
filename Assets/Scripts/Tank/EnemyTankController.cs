using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public class EnemyTankController : TankController
    {
        private float _refreshCounter;
        private NavMeshAgent _navMeshAgent;
        public EnemyTankController(Scriptable_Object.Tank.Tank tank, Vector3 position) : base(tank.TankView)
        {
            TankModel = new EnemyTankModel((EnemyTankModel)tank.TankModel);
            TankView.transform.position = new Vector3(position.x, TankView.transform.position.y, position.z);
            TankView.gameObject.AddComponent<NavMeshAgent>();
            _navMeshAgent = TankView.GetComponent<NavMeshAgent>();
            InitAIAgent();
            _navMeshAgent.SetDestination(GetRandomDestination());
            ResetCounter();
        }

        public override void Move()
        {
            if (_refreshCounter<=0)
            {
                _navMeshAgent.SetDestination(GetRandomDestination());
                
                ResetCounter();
                return;
            }
            _refreshCounter -= Time.fixedTime;
        }

        private void ResetCounter()
        {
            Debug.Log("Counter reset!"+((EnemyTankModel)TankModel).AiAgentModel.RefreshTime);
            _refreshCounter = ((EnemyTankModel) TankModel).AiAgentModel.RefreshTime;
        }

        private float GetRandomCoordinate()
        {
            float rand = Random.Range(-45, 45);
            return rand;
        }

        private Vector3 GetRandomDestination()
        {
            return new Vector3(GetRandomCoordinate(), TankView.transform.position.y, GetRandomCoordinate());
        }

        private void InitAIAgent()
        {
            EnemyTankModel theTankModel = (EnemyTankModel) TankModel;
            _navMeshAgent.height = 2;
            _navMeshAgent.radius = 2;
            _navMeshAgent.stoppingDistance = theTankModel.AiAgentModel.Range;
            _navMeshAgent.speed = theTankModel.Speed;
        }
    }
}