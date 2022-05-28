using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
   public TankView tankView;
   //public TankScriptableObject[] tankConfig;
   public TankScriptableObjectList tankList;
   public int tankTypeIndex;
   
    // Start is called before the first frame update
    void Start()
    {
        // for(int i = 0;i<3;i++){
        //    CreateTank(i); 
        // } 
       CreateTank();
    }

    private void CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankList.tanks[tankTypeIndex];
        // TankScriptableObject tankScriptableObject = tankList.tanks[index];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tankController = new TankController(tankModel,tankView);
        
    }

    
}
