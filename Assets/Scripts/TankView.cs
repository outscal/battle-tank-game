using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private TankModel tankModel;
    public TankType tankType;
    private float Shoot_;
    private float movement;
    private float rotation;
    public GameObject ShellPrefab;
    public GameObject ShellSpawnpos;
    float speed = 15;
    // float turnSpeed = 2;
    bool canShoot = true;

    public Rigidbody rb;
    public Rigidbody shell;

    void Update()
    {
        Movement();
        Fire_();
        if(movement != 0){
            tankController.Move(movement);
        }

        if(rotation != 0){
            tankController.Rotate(rotation, 30);
        }
            
        if(Shoot_ != 0){
            Fire(ShellPrefab,ShellSpawnpos);
        }

    }

    void CanShootAgain()
    {
        canShoot = true;
    }

    public void Fire( GameObject _ShellPrefab, GameObject _ShellSpawnpos)
    {
        Debug.Log("Outside");
        if(canShoot)
        {
            Debug.Log("Inside");
            GameObject shell = Instantiate(_ShellPrefab, _ShellSpawnpos.transform.position, _ShellSpawnpos.transform.rotation);
            shell.GetComponent<Rigidbody>().velocity   =  speed*this.transform.forward;
            canShoot=false;
            Invoke("CanShootAgain", 0.2f);
        }
    }
    private void Fire_(){
        Shoot_ = Input.GetAxis("Shoot");
    }

    private void Movement(){
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
    }

    public void SetTankController(TankController _tankController){
        tankController = _tankController;
    }

    // public GameObject ShootBullet(){
    //     GameObject shell = Instantiate(ShellPrefab, ShellSpawnpos.transform.position, ShellSpawnpos.transform.rotation);
    //     return shell;
    // }

    public Rigidbody GetRigidBody(){
        return rb;
    }

    // public Rigidbody GetBulletRigidBody(){
    //     return shell;
    // }
}