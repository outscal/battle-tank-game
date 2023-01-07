using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public Tank_View tankView;


    // Start is called before the first frame update
    void Start()
    {
        CreateTank();
    }

   private void CreateTank()
   {
        Tank_Model tankModel = new Tank_Model(10,60);
        Tank_Ctrl tankController = new Tank_Ctrl(tankModel, tankView); 
   }
}
