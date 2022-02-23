using UnityEngine;

namespace Tank
{
    public class EnemyTankController : TankController
    {
        private float refreshCounter;
        public EnemyTankController(Scriptable_Object.Tank.Tank tank, Vector3 position) : base(tank.TankView)
        {
            TankModel = new EnemyTankModel((EnemyTankModel)tank.TankModel);
            TankView.transform.position = new Vector3(position.x, TankView.transform.position.y, position.z);
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