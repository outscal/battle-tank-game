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
        private float healthCount;
        private float bulletDamage;
        public Renderer[] rend;
        private Material mat;
        private Color tankColor;
        private Vector3 currentEulerAngles;
        private Vector3 currentTankSpeed;
        public Rigidbody rb;
        public Transform bulletSpawner;


        public void SetViewDetails(EnemyModel model)
        {
            movingSpeed = model.EnemySpeed;
            rotatingSpeed = model.EnemyRotation;
            healthCount = model.EnemyHealth;
            tankColor = model.EnemyColor;
            bulletDamage = model.EnemyDamage;

            SetTankColor();
        }

        private void SetTankColor()
        {
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
