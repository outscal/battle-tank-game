using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TankSpawner : MonoBehaviour
{
    TankController tankController;
    [SerializeField] TankView tankView;
    [SerializeField] Joystick joystick;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    
    private void Start()
    {
        TankModel tankModel = new TankModel();
        tankView.joystick= joystick ;
        virtualCamera= tankView.virtualCamera ;
        tankController = new TankController(tankView, tankModel);
    }
}
