using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    private float movement;
    private float rotation;

    [SerializeField] public float movementSpeed;
    [SerializeField] public float rotationSpeed;
 
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if(movement != 0)
            tankController.TankMovement(movement, movementSpeed);

        if(rotation != 0)
            tankController.TankRotation(rotation, rotationSpeed);
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
