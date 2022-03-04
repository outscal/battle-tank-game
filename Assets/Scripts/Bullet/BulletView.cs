using UnityEngine;

namespace Bullet
{
    public class BulletView : MonoBehaviour
    {
        #region Public Propreties

        public BulletController BulletController { get; set; }

        #endregion

        #region Unity Functions

        private void FixedUpdate()
        {
            BulletController.Move();
        }

        private void OnCollisionEnter(Collision other)
        {
            BulletController.HitBy(other);
        }

        #endregion
    }
}