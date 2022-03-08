using UnityEngine;

namespace Tank
{
    public class EnemyTankController : TankController
    {
        #region Private Data members

        private float _refreshCounter;

        #endregion

        #region Constructors

        public EnemyTankController(Scriptable_Object.Tank.Tank tank, Vector3 position) : base(tank.TankView)
        {
            TankModel = new EnemyTankModel((EnemyTankModel)tank.TankModel);
            TankView.transform.position = new Vector3(position.x, TankView.transform.position.y, position.z);
            ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Idle);
            ((EnemyTankView)TankView).Idle.Init(((EnemyTankModel)TankModel).AiAgentModel.RefreshTime);
        }

        #endregion

        #region Protected Functions

        protected override void DestroyMe()
        {
            ((Interfaces.ITankService)EnemyTankService.Instance).Destroy(this);
        }

        #endregion

        #region Public Functions

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

        public void PlayerLost() => ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Idle);
        public void ReturnToChase() => ((EnemyTankView)TankView).ChangeStateTo(((EnemyTankView)TankView).Chase);

        #endregion
    }
}