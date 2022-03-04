using System.Collections;
using Attack;
using UnityEngine;

namespace Bullet
{
    public class BulletService : SingletonMB<BulletService>
    {
        [SerializeField] private ParticleSystem shellExplosion;

        public ParticleSystem ShellExplosion => shellExplosion;
        public BulletController CreateBullet(Attack.Attack attack)
        {
            BulletController newBulletController = null;
            switch(attack.Bullet.BulletModel.TrajectoryType)
            {
                case TrajectoryType.Linear:
                    newBulletController = new LinearBulletController((LinearAttack)attack);
                    break;
                case TrajectoryType.Tracking:
                    newBulletController = new TrackingBulletController((TrackingAttack)attack);
                    break;
            }

            return newBulletController;
        }

        public void Destroy(BulletController bulletController)
        {
            bulletController = null;
        }

        public void MakeExplosion(Collision collision)
        {
            StartCoroutine(ShowExplosion(collision));
        }
        private IEnumerator ShowExplosion(Collision collision)
        {
            Quaternion explosionRotation = Quaternion.Euler(-collision.contacts[0].normal);
            ParticleSystem explosion = Instantiate(shellExplosion, collision.contacts[0].point, explosionRotation);
            yield return new WaitForSeconds(1f);
            Destroy(explosion.gameObject);
        }
    }
}