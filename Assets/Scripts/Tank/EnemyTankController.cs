using Tank.States;
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
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Idle);
            ((EnemyTankView)TankView).Idle.Init(((EnemyTankModel)TankModel).AiAgentModel.RefreshTime);
        }

        public void Move()
        {
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Patroll);
            ((EnemyTankView)TankView).Patroll.Init(((EnemyTankModel)TankModel).AiAgentModel.RefreshTime);
        }

        public void HandleAttacks(PlayerTankView player)
        {
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Attack);
            ((EnemyTankView)TankView).Attack.Init(player);
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

        public void PlayerFound(PlayerTankView player)
        {
            ((EnemyTankView)TankView).Chase.SetTarget(player);
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Chase);
        }

        public void PlayerLost()
        {
            
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Idle);
        }

        public void ReturnToChase()
        {
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Chase);
        }
    }
}