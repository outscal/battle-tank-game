using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VFXServices;
using System.Threading.Tasks;
using System;

namespace BulletServices
{
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }
        private Coroutine destroy;
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void FixedUpdate()
        {
            bulletController.Movement();
        }
        private async void Start()
        {
            //write synchronous stuff for start() above this line --^
            await Task.Delay(TimeSpan.FromSeconds(2f));
            if (this != null)
                BulletService.instance.DestroyBullet(bulletController);
        }

        public void DestroyView()
        {
            bulletController = null;
            VFXService.instance.BulletEffects(transform.position);
            Destroy(this.gameObject);
        }
    }
}