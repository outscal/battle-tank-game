using UnityEngine;

public class EnemyTankController
{
   private EnemyTankModel enemyTankModel;
   private EnemyTankView enemyTankView;

   public EnemyTankController(EnemyTankModel _enemyTankModel, EnemyTankView _enemyTankView)
   {
       enemyTankModel = _enemyTankModel;
       enemyTankView = GameObject.Instantiate<EnemyTankView>(_enemyTankView);;
       
       enemyTankModel.SetEnemyTankController(this);
       enemyTankView.SetEnemyTankController(this);       
   }

   public EnemyTankModel GetEnemyTankModel()
   {
       return enemyTankModel;
   }

}
