using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// managing bullet views
    /// </summary>
    public class BulletView : MonoBehaviour
    {
        //private BulletController bulletController;
        //[SerializeField] private BulletType bulletType;
        //void Start()
        //{
        //    Debug.Log("bullet view created");
        //}

        //public void SetBulletController(BulletController _bulletController)
        //{
        //    bulletController = _bulletController;
        //}

        public BulletController bulletController { get; private set; }
        public ParticleSystem BullectDestroyVFX;
        public float m_MaxLifeTime = 1f;

        //setting bullet controller
        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        void Start()
        {
            // If it isn't destroyed by then, destroy the shell after it's lifetime.
            Destroy(gameObject, m_MaxLifeTime);
        }


        private void FixedUpdate()
        {
            bulletController.Movement();
        }

        void OnTriggerEnter(Collider other)
        {
            BullectDestroyVFX.transform.parent = null;
            BullectDestroyVFX.Play();

            Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
            Destroy(gameObject);
        }
    }
}