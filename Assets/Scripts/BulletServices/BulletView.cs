using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VFXServices;

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

        private void Update()
        {
            bulletController.Movement();
        }
        private void Start()
        {
            if (destroy == null)
                destroy = StartCoroutine(DestroyAfterSomeTime());
        }

        public void DestroyView()
        {
            bulletController = null;
            if (destroy != null)
            {
                StopCoroutine(destroy);
                destroy = null;
            }
            VFXService.instance.BulletEffects(transform.position);
            Destroy(this.gameObject);
        }


        private IEnumerator DestroyAfterSomeTime()
        {
            yield return new WaitForSeconds(5f);
            BulletService.instance.DestroyBullet(bulletController);
        }
    }
}