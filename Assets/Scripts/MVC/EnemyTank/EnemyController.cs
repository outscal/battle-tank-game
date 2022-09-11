using UnityEngine;

public class EnemyController
{
    
    private EnemyModel enemyModel;
    private EnemyView enemyView;

    private Rigidbody rb;

    public EnemyController (EnemyModel _enemymodel, EnemyView _enemyview)
    {
        enemyModel = _enemymodel;
        enemyView = GameObject.Instantiate<EnemyView>(_enemyview);
        rb = enemyView.GetRigidbody();
        enemyModel.SetEnemyController(this);
        enemyView.SetEnemyController(this);
    }

    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }

    public EnemyView GetEnemyView()
   {
       return enemyView;
   }
}
