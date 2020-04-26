using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Service;
using Tank.Controller;
using Tank.Model;
using Bullet.Service;

namespace Tank.View
{
    public class TankView : MonoBehaviour
    {
        private TankController tankController;
        private float health;
        private float speed;
        private float turn;

        public Transform firingLocation;

        void Start()
        {
            Debug.Log("Tank view created");
        }

        void Update()
        {
            tank_Movement();
            Fire();
        }

        private void Fire()
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                TankController.GetBulletModel(Transform firinLocation);
            }
        }

        private void tank_Movement()
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

        public void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.GetComponent<Bullet_Service>() != null)
            {
                reduce_Health();
                if (health < 10)
                {
                    tankController = null;
                }
            }
        }

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

        public void Sethealth(float p_Health)
        {
            health = p_Health;
        }

        public void SetSpeed(float p_Speed)
        {
            speed = p_Speed;
        }

        public void SetTurn(float p_turn)
        {
            turn = p_turn;
        }
    }
}