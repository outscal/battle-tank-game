using UnityEngine;

public class PlayerTankView : TankView
{
    public PlayerTankController PlayerTankController { get; set; }

    protected override void Update()
    {
        base.Update();

        if (PlayerTankController != null)
            PlayerTankController.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (PlayerTankController != null)
            PlayerTankController.FixedUpdate();
    }
}