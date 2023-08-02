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
}