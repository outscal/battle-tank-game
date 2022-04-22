using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement;
    private float rotation;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
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
        Movement();

        if(movement != 0)
            tankController.TankMovement(movement, tankController.GetTankModel().movementSpeed);
            
        if(rotation != 0)
            tankController.TankRotation(rotation, tankController.GetTankModel().rotationSpeed);
    }

     //method for setting the tankcontroller reference when we call this function
   public void SetTankController(TankController _tankController)
   {
       tankController = _tankController;
   }

   //method to get rigidbody
   public Rigidbody GetRigidBody()
   {
       return rb;
   }

   //method for tankmovement forward and backward
   private void Movement()
   {
       //getting the input left and right
       movement = Input.GetAxis("Vertical");
       rotation = Input.GetAxis("Horizontal");
   }
}
