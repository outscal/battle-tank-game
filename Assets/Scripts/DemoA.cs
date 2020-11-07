using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoA : MonoBehaviour
{
    void Start()
        {
            TankManager instancke = MonoSingeltonGeneric<TankManager>.getInstance(); 
        }
}
