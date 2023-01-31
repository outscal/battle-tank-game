
public class TankChasingState : TankState
{
    public override void OnEnterState()
    {
        base.OnEnterState();
        enemyTankView.enemyController.EnemyMechanism();
    }


}
