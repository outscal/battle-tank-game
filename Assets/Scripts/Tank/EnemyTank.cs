using UnityEngine;

public class EnemyTank : Tank<EnemyTank>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("EnemyTank:Awake():: {STARTED}");
    }
}