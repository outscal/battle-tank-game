using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : GenericSingletonClass<TankService>
{
    public GameObject tankPrefab;
    void Start()
    {
        GetTank();
    }

    private void Update()
    {
        
    }

    public void GetTank() 
    {
        Instantiate(tankPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}