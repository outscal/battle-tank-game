using UnityEngine;

public class PlayerTank : Tank<PlayerTank>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("PlayerTank:Awake():: {STARTED}");
    }
}