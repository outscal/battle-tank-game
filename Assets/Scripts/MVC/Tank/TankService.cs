using System.Collections;
using System.Collections.Generic;
using Assets.ScriptableObjects;
using Assets.Scripts.MVC.Tank;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public TankView tankView;
    // public EnemyView enemyView;
    PlayerMovement playerMovement;
    public TankScriptableObject[] tankConfigurations;

    [SerializeField] private FixedJoystick fixedjoyStick;
    private void Start()
    { 
        TankScriptableObject tankScriptableObject = tankConfigurations[Random.Range(0,4)];
        TankModel model = new TankModel(tankScriptableObject);
        TankController tank = new TankController(model, tankView);
        playerMovement.SetPlayerMovementReference(fixedjoyStick);   
    }
}
