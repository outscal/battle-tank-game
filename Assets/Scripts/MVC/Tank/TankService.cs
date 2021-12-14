using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    public TankView tankView;
    [SerializeField] private FixedJoystick fixedjoyStick;
    private void Start()
    {
        TankModel model = new TankModel(TankType.None, 5, 100f);
        TankController tank = new TankController(model, tankView);
        PlayerMovement movement = new PlayerMovement(obj, fixedjoyStick);
    }
}
