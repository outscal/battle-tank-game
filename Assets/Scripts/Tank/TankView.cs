using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TankGame.Event;

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
        public Slider slider;
        private TankModel model;
        private PlayerSfx currentSfx;


        private void Start()
        {
            EventService.Instance.OnPlayerSpawn();
            controller.PlaySound(PlayerSfx.Idle, true);
            currentSfx = PlayerSfx.Idle;
        }

        public void InitialiseController(TankController tankController)
        {
            controller = tankController;
        }

        public void SetViewDetails()
        {
            model = controller.TankModel;
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
            SetHealthBar();
        }

        private void SetHealthBar()
        {
            slider.value = healthCount;
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

        public TankController GetController()
        {
            return controller;
        }

        public void TakeDamage(float damage)
        {
            Debug.Log("taking damage");
            controller.ApplyDamage(damage);
        }

        public void Destroy()
        {
            ParticleService.Instance.CreateTankExplosion(this.transform.position, this.transform.transform.rotation);
            Destroy(gameObject, 0.1f);
        }

        public TankView GetView()
        {
            return this;
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
            horizontalInput = Input.GetAxisRaw("Horizontal1");
            verticalInput = Input.GetAxisRaw("Vertical1");
            if (verticalInput != 0)
            {
                if (currentSfx != PlayerSfx.Walk)
                {
                    controller.PlaySound(PlayerSfx.Walk, true);
                    currentSfx = PlayerSfx.Walk;
                }
            }
            else
            {
                if (currentSfx != PlayerSfx.Idle)
                {
                    controller.PlaySound(PlayerSfx.Idle, true);
                    currentSfx = PlayerSfx.Idle;
                }
            }

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