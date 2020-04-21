using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        private BulletController bullerController;
        public void SetBulletController(BulletController _bulletController)
        {
            bullerController = _bulletController;
        }

        private void Update()
        {
            bullerController.Movement();
        }
        private void Start()
        {
            Destroy(this.gameObject, 2f);
        }
    }

}