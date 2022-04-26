using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;   

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //CameraToFollowTank();
    }

    private void CameraToFollowTank()
    {
        //getting the gameobject of name Main Camera using find
        GameObject camera = GameObject.Find("Main Camera");
        //setting the tranform of the gameobject of this script to the parent of the camera
        camera.transform.SetParent(transform);
        //setting the trasfrom position value of the camera
        camera.transform.position = new Vector3(0f, 4f, -5f);

    }

    // Update is called once per frame
    void Update()
    {
        tankController.GetInput();
        tankController.Movement();        
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
