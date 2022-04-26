using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    [SerializeField]public TankView tankView;


    // Start is called before the first frame update
    void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        //creating tankmodel references
        TankModel tankModel = new TankModel(TankType.none, 15, 50);
        //creating tankcontroller object
        TankController tankController = new TankController(tankModel, tankView);            
    }
}
