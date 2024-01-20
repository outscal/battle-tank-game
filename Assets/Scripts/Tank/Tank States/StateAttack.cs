class StateAttack : TankState
{
    private TankState nextTankState;
    public StateAttack(EnemyTankController _tankController) : base(_tankController)
    {
        tankState = TankStates.attack;
    }

    public override void onStateEnter()
    {
        base.onStateEnter();
        tankController.toggleAutoFiring();
        tankController.fireAfterCooldown();
    }

    public override void onStateExit()
    {
        base.onStateExit();
        tankController.toggleAutoFiring();
        tankController.stopFiring();
        tankController.changeState(nextTankState);
    }

    public override void onTick()
    {
        base.onTick();
        tankController.lookAtPlayer();
        
        float reqDistance = tankController.distanceBtwPlayer();
        if (reqDistance > 5)
        {
            nextTankState = new StateChase(tankController);
            onStateExit();
        }
    }
}