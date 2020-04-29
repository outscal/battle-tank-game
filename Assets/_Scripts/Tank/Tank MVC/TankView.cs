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
        TankController tankController;

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
                StartCoroutine(HaltGameCoroutine());
            }
        }

        private void DestroyPlayer()
        {
            //Debug.Log("tank view destroyed");
            tankController.DestroyController();
            Destroy(gameObject);
        }

        private void VanishPlayer()
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
                r.enabled = false;
            tankController.SetOffParticleEffect(transform.position);
        }

        private IEnumerator HaltGameCoroutine()
        {
            VanishPlayer();
            Debug.Log("player vanish");
            yield return new WaitForSeconds(3f);
            Debug.Log("test time");
            tankController.DestroyAllEnemies();
            tankController.DestroyParticleEffect();
            DestroyPlayer();

            //Debug.Log("function called");
            
            //Destroy the particle effect just created. 

            //Destroy everything else.
            //"else" includes enemies - destroy all enemies one after the other slowly

            //destroying all enemies.
            //

            // then destroy the floor (the environment - different parts of environment at different times.)
        }

        public void SetTankController(TankController tc)
        {
            tankController = tc;
        }
    }

}