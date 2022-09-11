using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
   public TankView tankView;
   public TankScriptableObjectList tankList;
   public int tankTypeIndex;
   
    
    void Start()
    {
        
       CreateTank();
    }

    private void CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[tankTypeIndex];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tankController = new TankController(tankModel,tankView);
        
    }

    
}
