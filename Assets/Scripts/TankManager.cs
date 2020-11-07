using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoSingeltonGeneric<TankManager>
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Tank Manager created");
    }

}
