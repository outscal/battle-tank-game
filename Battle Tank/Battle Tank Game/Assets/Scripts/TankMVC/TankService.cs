using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField]public TankView tankView;

    //public TankScriptableObject[] tankConfigurations;
    public TankScriptableObjectList tankList;

    // Start is called before the first frame update
    void Start(){
        StartGame();
    }

    void StartGame()
    {
        CreateTank();
    }

    private void CreateTank()
    {
       // TankScriptableObject tankScriptableObject = tankConfigurations[2];
        TankScriptableObject tankScriptableObject = tankList.tanks[2];

        TankModel tankModel = new TankModel(tankScriptableObject);
        // TankModel tankModel = new TankModel(TankType.none, 15, 50);
        TankController tankController = new TankController(tankModel, tankView);            
    }
}
