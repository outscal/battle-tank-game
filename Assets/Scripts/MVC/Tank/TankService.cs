using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using Assets.Scripts.MVC.Tank;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    public TankScriptableObject[] tankConfigurations;
    private TankController tank;

    [SerializeField] private FixedJoystick fixedjoyStick;
    private void Start()
    {
        tank = createPlayerTank((TankType.Blue));
        setPlayerTankControlReference();
    }

    private TankController createPlayerTank(TankType tankType)
    {
        TankScriptableObject tankScriptableObject = tankConfigurations[Random.Range(0, 4)];
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        return tank;
    }

    private void FixedUpdate()
    {
        tank.FixedupdateTankController();
    }

    private void setPlayerTankControlReference()
    {
        tank.setJoystickreference(fixedjoyStick);
    }
}
