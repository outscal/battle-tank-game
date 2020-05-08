//using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using Tank.Controller;
using Bullet.View;
using Idamagable;

namespace Tank.View
{
    public class TankView : MonoBehaviour, IDamagable
    {
        bool isPlayerDead = false;
        TankController tankController;
        public ParticleSystem TankExplosion;

        public void SetTankController(TankController tc)
        {
            tankController = tc;
        }

        private void Update()
        {
            if (isPlayerDead)
            {
                StartCoroutine(HaltGame());
            }

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
                isPlayerDead = true;
            }
        }

        public void InstantiateTankExplosionParticleEffect()
        {
            Instantiate(TankExplosion, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }

        public void DestroyTankPrefab()
        {
            //Debug.Log("isplayerdead = " + isPlayerDead);
            Destroy(gameObject);
        }

        public IEnumerator HaltGame() //unable to halt the game.
        {
            Time.timeScale = 0.01f;
            isPlayerDead = false;
            yield return new WaitForSeconds(0.03f);
            tankController.DestroyTank();
            Time.timeScale = 1;
        }

        public void TakeDamage()
        {
            //implementation
        }
    }
}