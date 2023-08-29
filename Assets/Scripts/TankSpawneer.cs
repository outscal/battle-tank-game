using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawneer : GenericSingleton<TankSpawneer>
{
    public TankView tankView;
    // public TankScriptableObject[] tankConfigurations;
    public TankScriptableObjectList tankList;
    void Start()
    {
        // for(int i=0; i<3;i++){
        //     CreateTank();
        // }
        // Instantiate(tankView.gameObject,transform.position,Quaternion.identity);
        CreateTank();
    }

    private TankController CreateTank(){
        // TankScriptableObject tankScriptableObject = tankConfigurations[1];
        TankScriptableObject tankScriptableObject = tankList.tanks[1];
        TankModel tankModel = new TankModel(tankScriptableObject);
        // TankModel tankModel = new TankModel(TankType.None, 5, 100f);
        TankController tankController = new TankController(tankModel,tankView);
        return tankController;
    }
}