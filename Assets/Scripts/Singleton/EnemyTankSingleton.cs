using UnityEngine;

class EnemyTankSingleton : GenericSingleton<EnemyTankSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }
}