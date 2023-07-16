
using UnityEngine;

public class SingletonEnemyTank : GenericSingleton<SingletonEnemyTank>
{
    protected override void Awake()
    {
        base.Awake();
        InitializeEnemyTank();

    }

    private void InitializeEnemyTank()
    {
        Debug.Log("Enemy tank is Initialised");
    }

}
