using UnityEngine;

namespace Tank
{
    public class EnemyTankController : TankController
    {
        private float refreshCounter;
        public EnemyTankController(Scriptble_Object.Tank.Tank tank) : base(tank.TankView)
        {
            TankModel = new EnemyTankModel((EnemyTankModel)tank.TankModel);
        }

        public override void Move()
        {
            if (refreshCounter<=0)
            {
                ResetCounter();
                return;
            }

            refreshCounter -= Time.fixedTime;
        }

        private void ResetCounter()
        {
            Debug.Log("Counter reset!"+((EnemyTankModel)TankModel).AiAgentModel.RefreshTime);
            refreshCounter = ((EnemyTankModel) TankModel).AiAgentModel.RefreshTime;
        }
    }
}