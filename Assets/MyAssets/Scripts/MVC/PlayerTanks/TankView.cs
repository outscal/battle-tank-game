using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Model;
using Tank.Controller;
using Bullet.Model;

namespace Tank.View
{
    public class TankView : MonoBehaviour
    {
        public TankType tankType;

        private TankController tankController;
        private float health;
        private float speed;
        private float turn;

        public Transform firingLocation;
        //public Quaternion rotation;

        void Start()
        {
            Debug.Log("Tank view created");
        }

        void Update()
        { 
            Tank_Movement();
            Fire();
        }

        private void Fire()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                tankController.ShootBullet();
                Debug.Log("F pressed");
            }
        }

        private void Tank_Movement()
        {
            float Turning = Input.GetAxis("HorizontalUI");
            float Accelerate = Input.GetAxis("VerticalUI");

            if (Accelerate > 0)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            if (Accelerate < 0)
            {
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            }

            if (Turning > 0)
            {
                transform.Rotate(Vector3.up * turn * Time.deltaTime);
            }

            if (Turning < 0)
            {
                transform.Rotate(-Vector3.up * turn * Time.deltaTime);
            }

        }

        /*public void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.GetComponent<>() != null)
            {
                reduce_Health();
                if (health < 10)
                {
                    tankController = null;
                }
            }
        }*/

        public void reduce_Health()
        {
            if (health > 10)
            {
                health -= 10;
            }
        }

        public void SetController(TankController t_Controller)
        {
            tankController = t_Controller;
        }

        public void SetSpeed(float p_Speed)
        {
            speed = p_Speed;
        }

        public void SetTurn(float p_turn)
        {
            turn = p_turn;
        }
        public void Sethealth(float p_Health)
        {
            health = p_Health;
        }
    }
}