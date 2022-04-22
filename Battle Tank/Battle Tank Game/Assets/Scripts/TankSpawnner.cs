using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnner : MonoBehaviour
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
        TankModel tankModel = new TankModel();
        //creating tankcontroller object
        TankController tankController = new TankController(tankModel, tankView);            
    }
}
