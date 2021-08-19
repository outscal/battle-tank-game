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
                //Destroy(gameObject);
                //this.gameObject.SetActive(false);
            }
            else if (collision.gameObject.GetComponent<TankView>() != null)
            {   
                TankService.Instance.GetTankController().ApplyDamage(bulletController.bulletModel.Damage);
                //Destroy(collision.gameObject);
                ////collision.gameObject.SetActive(false);
                //Destroy(gameObject);
                //this.gameObject.SetActive(false);
            }
                Destroy(gameObject);
        } 
    }
}