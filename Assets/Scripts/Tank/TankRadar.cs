using System;
using UnityEngine;

public class TankRadar : MonoBehaviour
{
    #region Public Events

    public event Action<Tank.PlayerTankView> PlayerFound; 
    public event Action PlayerEscaped;

    #endregion

    #region Unity Functions

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Tank.PlayerTankView>()) PlayerFound.Invoke(other.GetComponent<Tank.PlayerTankView>());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Tank.PlayerTankView>()) PlayerEscaped.Invoke();
    }

    #endregion
}
