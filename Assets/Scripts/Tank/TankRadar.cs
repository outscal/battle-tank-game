using System;
using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

public class TankRadar : MonoBehaviour
{
    public event Action<PlayerTankView> PlayerFound = delegate(PlayerTankView view) {  }; 
    public event Action PlayerEscaped = delegate {  };

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerTankView>()) PlayerFound.Invoke(other.GetComponent<PlayerTankView>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerTankView>()) PlayerEscaped.Invoke();
    }
}
