using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
   public TankView tankView;
   public TankScriptableObject[] tankConfig;
   
    // Start is called before the first frame update
    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankScriptableObject tankScriptableObject = tankConfig[4];
        TankModel tankModel = new TankModel(tankScriptableObject);
        TankController tankController = new TankController(tankModel,tankView);
        
    }

    
}
