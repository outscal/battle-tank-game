using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankView : MonoBehaviour
{
    public GameObject Turret;

    private PlayerTankController TankController; 

    private void Update()
    {
    }

    public void SetTankControllerReference(PlayerTankController controller)
    {
        TankController = controller;
    }
}
