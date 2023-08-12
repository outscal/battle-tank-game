using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public TankView tankPrefab;
    void Start()
    {
        
    }

   private void TankCreator()
    {
        TankModel tankModel= new TankModel();
        TankController tankCon = new TankController(tankModel, tankPrefab);
    }
}
