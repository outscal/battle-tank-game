using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame.Enemy
{
    public class EnemyView : MonoBehaviour, IDamagable
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
        private EnemyState currentState;
        private EnemyState startingState;
        public EnemyPatroling patrolingState;
        public EnemyChasing chasingState;
        public EnemyAttacking attackingState;
        private float speedMUltiplier;
        public Slider slider;
        private EnemyModel model;

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
            startingState = patrolingState;  // setting patroling state as starting state
            ChangeState(startingState);
            //InvokeRepeating("FireBullet", 1f, fireRateDelay);
        }
        public void SetViewDetails( )
        {
            model = controller.EnemyModel;  
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

        public float GetFireRate()
        {
            return fireRateDelay;
        }
        public void SetTankHealth(float EnemyHealth)
        {
            healthCount = EnemyHealth;
            SetHealthBar();
        }

        private void SetHealthBar()
        {
            slider.value = healthCount;
        }

        public void SetTankDamage(float EnemyDamage)
        {
            bulletDamage = EnemyDamage;
        }

        public void SetTankColor(Color EnemyColor)
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
            //moveTank();
        }
        public void TakeDamage(float damage)
        {
            controller.ApplyDamage(damage);
        }

        public void Destroy()
        {
            ParticleService.Instance.CreateTankExplosion(this.transform.position, this.transform.transform.rotation);
            Destroy(gameObject, 0.1f);
        }
        //public void ApplyEnemyDamage(float damage)
        //{
        //    healthCount -= damage;
        //    if (healthCount <= 0)
        //    {
        //        controller.DestroyEnemyView(this);
        //    }
        //}

        public void FireBullet()
        {
            EnemyService.Instance.fire(bulletSpawner, bulletDamage);
            //Debug.Log("enemy view bullet");
        }

        public void moveTank()
        {
            currentEulerAngles += new Vector3(0, 1, 0) * Time.deltaTime * rotatingSpeed;
            transform.eulerAngles = currentEulerAngles;
            //currentTankSpeed += new Vector3(0, 0, verticalInput) * Time.deltaTime * movingSpeed;
            //transform.forward = currentTankSpeed;
            rb.velocity = transform.forward * 1 * Time.deltaTime * movingSpeed;
        }

        public void ChangeState(EnemyState newState)
        {
            if (currentState != null)
            {
                currentState.OnExitState(); // to clear all running states and coroutines
            }
            currentState = newState;
            currentState.OnEnterState();
        }

    }
}
