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
                //Debug.Log("fucntion called");
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
                //tankController.DestroyTank();
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
            //Debug.Log("func called");
            //Time.timeScale = 0;
            //Debug.Log("next stat");
            isPlayerDead = false;
            //Debug.Log("next stat2");
            yield return new WaitForSeconds(3f);
            //Debug.Log("next stat3");
            //yield return StartCoroutine(Cor2());
            //Debug.Log("next stat4");
            
            //yield return new WaitForSeconds(3f);
            //Debug.Log("next stat5");
            //yield return StartCoroutine(Cor3());

            tankController.DestroyTank();
            //Time.timeScale = 1;
        }

        //public IEnumerator Cor2()
        //{
        //    Debug.Log("next stat6");
        //    yield return new WaitForSeconds(2f);
        //    Debug.Log("next stat7");
        //}

        //public IEnumerator Cor3()
        //{
        //    Debug.Log("next stat8");
        //    yield return new WaitForSeconds(5f);
        //    Debug.Log("next stat9");
        //}
    }

}