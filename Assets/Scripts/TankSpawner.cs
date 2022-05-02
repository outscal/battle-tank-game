using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
   public TankView tankView;
   
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tankView.gameObject,transform.position,Quaternion.identity);
    }

    
}
