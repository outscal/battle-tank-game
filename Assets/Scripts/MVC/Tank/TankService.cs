using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;

    public TankScriptableObject[] tankConfigurations;

    //[SerializeField] private FixedJoystick fixedjoyStick;
    private void Start()
    { 
        TankScriptableObject tankScriptableObject = tankConfigurations[3];
        //TankModel model = new TankModel(TankType.None, 5, 100f);
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        //PlayerMovement v = Object.Instantiate(PlayerMovement(fixedjoyStick));
    }
}
