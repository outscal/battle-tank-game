using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerTankView : TankView
{
    protected override void PlayerTankInput()
    {
        playerTurnHorizontal = Input.GetAxisRaw("Horizontal");
        playerMoveVertical = Input.GetAxisRaw("Vertical");
    }
}
