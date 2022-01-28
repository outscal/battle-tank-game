using Assets.Scripts.MVC.Tank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(PlayerMovement))]
public class TankView : MonoBehaviour, IDamagable
{
    public TankType tankType;
    private TankController tankController;

    public void TakeDamage(int damage)
    {
        Debug.Log("Taking Damage"  );
        tankController.ApplyDamage(damage);
    }

    public void setTankControllerReference(TankController tankController)
    {
        this.tankController = tankController;
    }
    private void Start()
    {
        //Debug.Log("Tank View Created");
        //playerMovement.SetPlayerMovementReference(TankService);
        
      
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
       // Debug.Log("View Class Update called");
    }
}
