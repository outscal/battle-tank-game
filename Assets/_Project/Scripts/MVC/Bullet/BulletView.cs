using BattleTank.Enum;
using BattleTank.Interface;
using BattleTank.Services;
using UnityEngine;

namespace BattleTank.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private BulletController bulletController;
        [SerializeField] private Rigidbody rigidBody;
        
        public Rigidbody GetRigidBody()
        {
            return rigidBody;
        }

        public void SetBulletController(BulletController _bulletController)
        {
            bulletController = _bulletController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<IDamageable>() != null)
            {
                IDamageable damagableObject = other.GetComponent<IDamageable>();
                damagableObject.Damage(bulletController.GetTankID(), bulletController.GetDamageValue());
            }
            ParticleEffectsService.Instance.ShowExplosionEffect(ExplosionType.BulletExplosion, gameObject.transform.position);
            DestroyGameObject();
        }

        public void DestroyGameObject()
        {
            Destroy(gameObject);
        }
    }
}