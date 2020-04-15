using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame.Enemy
{
    public class EnemyView : MonoBehaviour
    {
        private float horizontalInput;
        private float verticalInput;
        private int rotatingSpeed;
        private int movingSpeed;
        private float fireRateDelay;
        private float healthCount;
        private float bulletDamage;
        public Renderer[] rend;
        private Material mat;
        private Color tankColor;
        private Vector3 currentEulerAngles;
        private Vector3 currentTankSpeed;
        public Rigidbody rb;
        public Transform bulletSpawner;
        private EnemyController controller;
       [HideInInspector]
        public EnemyTankType tankType;
        private EnemyScriptableObject ResetEnemyObject;
        public void InitializeController(EnemyController enemyController)
        {
             controller = enemyController;
        }

        public EnemyController GetController()
        {
            return controller;
        }

        private void Start()
        {
            InvokeRepeating("FireBullet",1f,fireRateDelay);
        }
        public void SetViewDetails(EnemyModel model, EnemyScriptableObject enemyScriptableObject)
        {
            tankType = model.EnemyTankType;

            SetTankSpeed(model.EnemySpeed, model.EnemyRotation);
            SetFireRate(model.EnemyFireRateDelay);
            SetTankHealth(model.EnemyHealth);
            SetTankDamage(model.EnemyDamage);
            SetTankColor(model.EnemyColor);
        }

        public void SetTankSpeed(int EnemySpeed, int EnemyRotation)
        {
            movingSpeed = EnemySpeed;
            rotatingSpeed = EnemyRotation;
        }
        public void SetFireRate(float FireRateDelay)
        {
            fireRateDelay = FireRateDelay;
        }

        public void SetTankHealth(float EnemyHealth)
        {
            healthCount = EnemyHealth;
        }
        public void SetTankDamage(float EnemyDamage)
        {
            bulletDamage = EnemyDamage;
        }

        private void SetTankColor(Color EnemyColor)

        {
            tankColor = EnemyColor;
            for (int i = 0; i < rend.Length; i++)
            {
                mat = rend[i].material;
                mat.color = tankColor;
            }
        }
        private void FixedUpdate()
        {
            //horizontalInput = Input.GetAxisRaw("HorizontalUI");
            //verticalInput = Input.GetAxisRaw("VerticalUI");
            moveTank();
        }

        public void ApplyEnemyDamage(float damage)
        {
            healthCount -= damage;
            if (healthCount <= 0)
            {
                controller.DestroyEnemyView(this);
            }
        }

        private void FireBullet()
        {
            EnemyService.Instance.fire(bulletSpawner, bulletDamage);
        }

        //private void Update()
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        EnemyService.Instance.fire(bulletSpawner, bulletDamage);
        //    }
        //}

        private void moveTank()
        {
            currentEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * rotatingSpeed;
            transform.eulerAngles = currentEulerAngles;
            //currentTankSpeed += new Vector3(0, 0, verticalInput) * Time.deltaTime * movingSpeed;
            //transform.forward = currentTankSpeed;
            rb.velocity = transform.forward * 1 * Time.deltaTime * movingSpeed;

        }

    }
}
