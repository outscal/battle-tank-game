using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// managing bullet views
    /// </summary>
    public class BulletView : MonoBehaviour
    {
        public BulletController bulletController { get; private set; }
        public ParticleSystem BullectDestroyVFX;
        public float m_MaxLifeTime = 1f;
        public Transform target;

        void Start()
        {
           target= TankService.Instance.PlayerPos();
        }

        private void FixedUpdate()
        {
            bulletController.Movement();
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyTankView>() != null)
            {
                Destroy(collision.gameObject);
                this.gameObject.SetActive(false);
            }
            else if (collision.gameObject.GetComponent<TankView>() != null)
            {
                //Destroy(collision.gameObject);
                collision.gameObject.SetActive(false);
                this.gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
        }  

        void DoDamage()
        {

        }
        //void OnTriggerEnter(Collider other)
        //{
        //    BullectDestroyVFX.transform.parent = null;
        //    BullectDestroyVFX.Play();

        //    Destroy(BullectDestroyVFX.gameObject, BullectDestroyVFX.main.duration);
        //    Destroy(gameObject);
        //}
    }
}