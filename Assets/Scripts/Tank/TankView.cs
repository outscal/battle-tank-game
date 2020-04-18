using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Tank
{
    public class TankView : MonoBehaviour, IDamagable
    {

        private float horizontalInput;
        private float verticalInput;
        private int rotatingSpeed;
        private int movingSpeed;
        private float healthCount;
        private float bulletDamage;
        private float fireRateDelay;
        public Renderer[] rend;
        private Material mat;
        private Color tankColor;
        private Vector3 currentEulerAngles;
        private Vector3 currentTankSpeed;
        public Rigidbody rb;
        public Transform bulletSpawner;
        private TankController controller;


        public void SetViewDetails(TankModel model)
        {
            Camera.main.GetComponentInParent<CamaeraFollow>().setTarget(gameObject.transform);

            SetTankSpeed(model.MovingSpeed, model.RotatingSpeed);
            SetTankHealth(model.Health);
            SetTankDamage(model.BulletDamage);
            SetTankColor(model.TankColor);
        }

        public void SetTankSpeed(int Speed, int Rotation)
        {
            movingSpeed = Speed;
            rotatingSpeed = Rotation;
        }
        public void SetFireRate(float FireRateDelay)
        {
            fireRateDelay = FireRateDelay;
        }

        public void SetTankHealth(float Health)
        {
            healthCount = Health;
        }
        public void SetTankDamage(float Damage)
        {
            bulletDamage = Damage;
        }
        private void SetTankColor(Color tankColor)
        {
            for (int i = 0; i < rend.Length; i++)
            {
                mat = rend[i].material;
                mat.color = tankColor;
            }
        }

        public void InitialiseController(TankController tankController)
        {
            controller = tankController;
        }

        public TankController GetController()
        {
            return controller;
        }

        public void TakeDamage(float damage)
        {
            controller.ApplyDamage(damage, this);
        }
        //public void ApplyPlayerTankDamage(float damage)
        //{
        //    healthCount -= damage;
        //    if (healthCount <= 0)
        //    {
        //        controller.DestroyTankView(this);
        //    }
            
        //}

        private void FixedUpdate()
        {
            horizontalInput = Input.GetAxisRaw("HorizontalUI");
            verticalInput = Input.GetAxisRaw("VerticalUI");
            moveTank();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                controller.fire(bulletSpawner, bulletDamage);
            }
        }

        private void moveTank()
        {
            currentEulerAngles += new Vector3(0, horizontalInput, 0) * Time.deltaTime * rotatingSpeed;
            transform.eulerAngles = currentEulerAngles;
            //currentTankSpeed += new Vector3(0, 0, verticalInput) * Time.deltaTime * movingSpeed;
            //transform.forward = currentTankSpeed;
            rb.velocity = transform.forward * verticalInput * Time.deltaTime * movingSpeed;

        }

    }
}