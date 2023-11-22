using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankView : MonoBehaviour, IDamageable
{
    private TankController tankController;
    private TankModel tankModel;
    public TankType tankType;
    private float movement;
    private float rotation;
    float speed ;
    public Rigidbody rb;

    private void Awake(){
        rb = GetComponent<Rigidbody>();

        if(rb == null){
            Debug.LogError("RigidBody not found");
        }
    }

    

     private void Update()
        {
            Movement();

             if (movement != 0)
            {
                tankController.Move(movement, tankController.TankModel.Speed);
            }

            if (rotation != 0)
                tankController.Rotate(rotation, tankController.TankModel.Speed);

        }

    private void Movement(){
        rotation = Input.GetAxis("Horizontal");
        movement = Input.GetAxis("Vertical");
    }

    public void SetTankController(TankController _tankController){
        tankController = _tankController;
    }

 
    public Rigidbody GetRigidBody(){
        return rb;
    }

    public void TakeDamage(BulletType bulletType, int damage){

        Debug.Log("Take damge " + damage + "from bullettype " + bulletType);
        tankController.ApplyDamage(bulletType, damage);
    }    

    public void Initalise(TankController tankController){
        this.tankController = tankController;
    }   

   
}