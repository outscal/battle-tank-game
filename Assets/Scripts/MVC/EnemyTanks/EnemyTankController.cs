using UnityEditor;
using UnityEngine;

namespace Outscal.BattleTank 
{
    /// <summary>
    /// enemy tnak controller class
    /// </summary>
    public class EnemyTankController
    {
        private Rigidbody rigidbody;
        public EnemyTankModel EnemyTankModel { get; private set; }
        public EnemyTankView EnemyTankView { get; private set; }


        public EnemyTankController(EnemyTankModel enemyTankModel,EnemyTankView enemyTankView)
        {
            EnemyTankModel = enemyTankModel;
            EnemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankView);
            rigidbody = EnemyTankView.GetComponent<Rigidbody>();
        }  
    }
}