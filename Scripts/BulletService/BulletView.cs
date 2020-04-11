using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bullerController;



        public void GetBulletController(BulletController _bulletController)
        {
            bullerController = _bulletController;
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            bullerController.bulletService.transform.Translate(Vector3.forward * bullerController.bulletModel.speed * Time.deltaTime);
        }
    }

}