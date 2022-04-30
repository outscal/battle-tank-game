using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;

    public GameObject[] tankBody;   

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Intitalization();
        CameraToFollowTank();
        ChangeTankColor();
    }

    void Update()
    {
        tankController.GetInput();
        tankController.Movement();        
    }

    private void Intitalization()
    {
        tankBody = GameObject.FindGameObjectsWithTag("TankBody");        
    }      

    private void CameraToFollowTank()
    {        
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.SetParent(transform);
        camera.transform.position = new Vector3(0f, 4f, -5f);
    }

    private void ChangeTankColor()
    {
        for(int i = 0; i < tankBody.Length; i++)
        {
            tankBody[i].GetComponent<Renderer>().material.color = tankController.GetTankModel().tankColor;
        }
    }
    
    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

   //method to get rigidbody
   public Rigidbody GetRigidBody()
   {
       return rb;
   }   
}
