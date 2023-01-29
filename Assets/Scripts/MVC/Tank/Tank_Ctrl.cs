using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Ctrl 
{
    public Tank_Model tankmodel;
    private Tank_View tankview;
    private Rigidbody rb;
    public TankType tanktype;


    public Tank_Ctrl(Tank_Model _tankModel, Tank_View _tankView)
    {
        tankmodel = _tankModel;
        tankview = _tankView;
        tankview = GameObject.Instantiate<Tank_View>(_tankView);
        rb = tankview.GetRigidbody();
        tankview.SetTankController(this);
    }

    public void Move(float movement, float movementeSpeed)
    {
        rb.velocity = tankview.transform.forward * movement * movementeSpeed;
    }

    public void Roatate(float rotate, float rotatespeed)
    {
        Vector3 vector = new Vector3(0f, rotate * rotatespeed, 0f);
        Quaternion deltaRotation = Quaternion.Euler(vector * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    public Tank_Model GetTankModel()
    {
        return tankmodel;
    }

    public Transform Playerpos() { return tankview.transform; }
    public int TankHealth() { return tankmodel.Health; }
}
