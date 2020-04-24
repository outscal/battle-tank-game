using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet.Controller;
using Enemy.View;

namespace Bullet.View
{
    public class BulletView : MonoBehaviour
    {
        BulletController bulletController;
        //Rigidbody rigidbody;
        private void Awake()
        {
            Debug.Log("Bullet View created");
            //rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            FireBullet(transform.eulerAngles);
        }

        public void FireBullet(Vector3 tankRotation)
        {
            transform.eulerAngles = tankRotation;

            //Vector3 position = transform.position; // *** this violates the MVC design pattern . need to find a better way. have to move the logic of firing the bullet inside the bullet controller script.
            //position.x += bulletController.BulletModel.Speed * Time.deltaTime;
            //transform.position = position;

            transform.position += transform.forward * bulletController.BulletModel.Speed * Time.deltaTime;

            //rigidbody.velocity = transform.forward * bulletController.BulletModel.Speed * Time.deltaTime;

            //transform.Translate(Vector3.forward * bulletController.BulletModel.Speed * Time.deltaTime);

            CheckBulletBounds();

        }

        private void CheckBulletBounds()
        {
            if ((Mathf.Abs(transform.position.x) > 48f) || (Mathf.Abs(transform.position.z) > 48f))
            {
                DestroyBullet();
            }
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("Boundaries"))
        //    {
        //        Debug.Log("Destroy Bullet");
        //        //DestroyBullet();
        //    }
        //}

        //private void OnCollisionEnter(Collision collision)
        //{
        //    Debug.Log("function called");

        //    if (collision.gameObject.GetComponent<EnemyView>() != null)
        //    {
        //        Debug.Log("if function called");
        //        DestroyEnemy();
        //        DestroyBullet();
        //    }
        //}

        //private void DestroyEnemy()
        //{
        //    Debug.Log("Destroy Enemy");
        //}

        private void DestroyBullet()
        {
            Debug.Log("bullet view destroyed...");
            bulletController.DestroyController();
            Destroy(gameObject);
        }

        public void SetBulletController(BulletController bc)
        {
            bulletController = bc;
        }
    }
}