using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public class EnemyTankController : TankController
    {
        private float _refreshCounter;
        public EnemyTankController(Scriptable_Object.Tank.Tank tank, Vector3 position) : base(tank.TankView)
        {
            TankModel = new EnemyTankModel((EnemyTankModel)tank.TankModel);
            TankView.transform.position = new Vector3(position.x, TankView.transform.position.y, position.z);
            InitAIAgent();
            ResetDestination();
        }

        public override void Move()
        {
            if (_refreshCounter<=0)
            {
                ResetDestination();
                return;
            }
            _refreshCounter -= Time.fixedDeltaTime;
        }

        public override void HandleAttacks()
        { }

        private void ResetDestination()
        {
            ((EnemyTankView) TankView).NavMeshAgent.SetDestination(GetRandomDestination());
            ResetCounter();
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
            return new(GetRandomCoordinate(), TankView.transform.position.y, GetRandomCoordinate());
        }

        private void InitAIAgent()
        {
            EnemyTankModel theTankModel = (EnemyTankModel) TankModel;
            ((EnemyTankView) TankView).NavMeshAgent.height = 2;
            ((EnemyTankView) TankView).NavMeshAgent.radius = 2;
            ((EnemyTankView) TankView).NavMeshAgent.stoppingDistance = theTankModel.AiAgentModel.Range;
            ((EnemyTankView) TankView).NavMeshAgent.speed = theTankModel.Speed;
        }

        protected override void DestroyMe()
        {
            ((ITankService)EnemyTankService.Instance).Destroy(this);
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            if(TankModel.Health<=0) DestroyMe();
        }
    }
}