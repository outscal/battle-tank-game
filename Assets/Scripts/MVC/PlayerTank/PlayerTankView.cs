using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankView : MonoBehaviour, IDamagable
{
    public GameObject Turret;

    private PlayerTankController tankController; 

    public void SetTankControllerReference(PlayerTankController controller)
    {
        tankController = controller;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        tankController.TakeDamage(damage); 
    }
}
