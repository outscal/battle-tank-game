using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
  private TankController tankController;

  private float health;
  private float speed;
  private float turn;

  private Rigidbody rb;

    void Start()
    {
		Debug.Log("Tank view created");
    rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
      tank_Movement();
      //Fire();
    }

    private void tank_Movement()
    {
      Vector3 position = transform.position;
      Quaternion rotation = transform.rotation;

      float Turning = Input.GetAxis("HorizontalUI");
      float Accelerate = Input.GetAxis("VerticalUI");
    
      if(Accelerate > 0)
      {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
      }

      if(Accelerate < 0)
      {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
      }

      if(Turning > 0)
      {
        transform.Rotate(Vector3.up * turn * Time.deltaTime);
      }

      if(Turning < 0 )
      {
        transform.Rotate(-Vector3.up * turn * Time.deltaTime);
      }
      
    }

    public void OnCollisionEnter(Collision coll)
    {
      if(coll.gameObject.GetComponent<Bullet_Service>() != null)
      {
        reduce_Health();
        if(health < 10)
        {
          tankController= null;
        }
      }
    }

    public void reduce_Health()
    {
      if(health > 10)
      {
        health -= 10;
      }
    }

    public void setController(TankController t_Controller)
    {
      tankController = t_Controller;
    }

    public void sethealth(float p_Health)
    {
      health = p_Health;
    }

    public void setSpeed(float p_Speed)
    {
      speed = p_Speed;
    }
    
    public void setTurn(float p_turn)
    {
      turn = p_turn;
    }
}