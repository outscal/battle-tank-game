using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    private ShellController ShellController { get; set; }
    public void SetShellController(ShellController shellController)
    {
        ShellController = shellController;
    }

    public Rigidbody GetRigidbody() 
    {
        return GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (ShellController != null)
        {
            ShellController.Shot();
            Destroy(gameObject, 5f);
        }
        else
        {
            return;
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable;
        if ((damagable = collision.gameObject.GetComponent<IDamagable>()) != null)
        {
            // Apply appropriate damage to the damagable.
            damagable.TakeDamage(ShellController.GetShellModel().Damage);
        }
    }
}
