using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank.Controller;
using Bullet.View;

namespace Tank.View
{
    public class TankView : MonoBehaviour
    {
        public PlayerTankType TankType;
        TankController tankController;

        void Start()
        {
            Debug.Log("Tank View created");
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal1");
            float vertical = Input.GetAxisRaw("Vertical1");
            float turnSmoothVelocity = 0f;
            float turnSmoothTime = 0.05f;

            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, tankController.GetTargetRotation(horizontal, vertical), ref turnSmoothVelocity, turnSmoothTime);

            Vector3 position = transform.position;
            transform.position = tankController.MoveTank(horizontal, vertical, position);

            if (Input.GetKeyDown(KeyCode.F))
            {
                tankController.FireBullet(transform.position, transform.eulerAngles);
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BulletView>() != null)
            {
                DestroyPlayer();
                DestroyBullet();
            }
        }

        private void DestroyBullet()
        {
            tankController.DestroyBullet();
        }

        private void DestroyPlayer()
        {
            Debug.Log("tank view destroyed");
            tankController.DestroyController();
            Destroy(gameObject);
        }

        public void SetTankController(TankController tc)
        {
            tankController = tc;
        }
    }

}