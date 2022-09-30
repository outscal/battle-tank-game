using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class TankService : MonoBehaviour
{
    TankController tankController;
    [SerializeField] TankView tankView;
    [SerializeField] Joystick joystick;
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] TankScriptableObjectList tanksList;
    [SerializeField] int spawnIndex;
    private void Start()
    {
        if (tanksList.tanks.Count <= spawnIndex)
        {
            Debug.LogError("Wrong Index entered. Check the index for " +
                "spawning the tank!!!");
            spawnIndex = 0;
        }
        TankModel tankModel = new TankModel(tanksList.tanks[spawnIndex], spawnIndex);
        tankView.materialFromScriptableObject = tanksList.tanks[spawnIndex].tankMaterial;
        tankView.joystick = joystick;
        tankController = new TankController(tankView, tankModel, spawnIndex);
    }
}
