using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoBehaviour
{
    public Vector3 spawnLoc = new Vector3(0, 0, 0); 
    public TankView tankView;
     TankController tankController;
     TankModel tankModel1, tankModel2, tankModel3; 


    
    // Start is called before the first frame update
    void Start()
    {
        CreateTanks(); 
       



    }

    // Should have a spwan method to spawn the tank on a random location 
    // should have movement controller; 
    // should have bullet spawner 

    public void CreateTanks()
    {
        for(int i =0; i<3 ; i++)
        {
            tankModel1 = new TankModel(TankType.Red, 5.0f, 100f, Color.red);
            tankController = new TankController(tankModel1, tankView, spawnLoc);
        }         
    }

    //public void SpwanTank()
    //{
    //    CreateTanks(); 
    //}

   
    void Update()
    {
        
    }
}
