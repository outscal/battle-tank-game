using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_View : MonoBehaviour
{
    private Tank_Ctrl tankController;
    private float movement;
    private float rotation;
    private float health;
    public Transform bulletspawnPos;
    TankBulletController tankBulletController;


    public TankType tankType;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
    }

    private void Update()
    {
        Movement();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().Speed);
        }

        if(rotation != 0)
        {
            tankController.Roatate(rotation, tankController.GetTankModel().RotationSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TankBulletService.Instance.CreateNewBullet(bulletspawnPos);
            Debug.Log("Shooting Bullet");
            tankBulletController.ShootBullet();
        }
    }

    private void Movement()
    {
        movement = Input.GetAxis("Horizontal");
        rotation = Input.GetAxis("Vertical");
    }

    public void SetTankController(Tank_Ctrl _tankCtrl)
    {
        tankController = _tankCtrl;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
