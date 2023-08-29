using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;

    public GameObject target;
    public GameObject parent;   
    float speed = 15;
    bool canShoot = true;

    private Rigidbody rb;
    private Rigidbody shell;
    public float H;

    public TankController(TankModel _tankModel, TankView _tankView){
        tankModel = _tankModel;
        tankView = GameObject.Instantiate<TankView>(_tankView);
        rb = tankView.GetRigidBody();
        tankModel.SetTankController(this);
        tankView.SetTankController(this);
        H = tankModel.Health;
    }

    public void Move(float movement){
        rb.velocity = tankView.transform.forward*movement*tankModel.Speed;
        
    }

    public void Rotate(float rotate, float rotateSpeed){
        Vector3 vector = new Vector3(0f, rotate*rotateSpeed,0f);
        Quaternion deltaRotation = Quaternion.Euler(vector*Time.deltaTime);
        rb.MoveRotation(rb.rotation*deltaRotation);
    }

    void CanShootAgain()
    {
        canShoot = true;
    }

    // public void Fire()
    // {
    //     if(canShoot)
    //     {
    //         // GameObject _shell = tankView.ShootBullet();
    //         shell = tankView.GetBulletRigidBody();
    //         shell.velocity   =  speed*tankView.transform.forward;
    //         canShoot=false;
    //         tankView.Invoke("CanShootAgain", 0.2f);
    //     }
    // }
}
