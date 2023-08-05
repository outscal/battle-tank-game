using UnityEngine;

public class EnemyTankView : TankView
{
    public EnemyTankController EnemyTankController { get; set; }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (EnemyTankController != null)
            EnemyTankController.FixedUpdate();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (EnemyTankController != null)
            EnemyTankController.OnCollisionEnter(collision);
    }
}