
using System;
using UnityEngine;

public class TankView : MonoBehaviour
{
    public TankController tankController;

    public void getTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
};
