using UnityEngine;
using BTManager;

namespace Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : MonoBehaviour
    {
        private Rigidbody rb;
        private Vector3 lastVelocity;

        [HideInInspector]
        public BulletController bulletController;

        private float currentTime, destroyTime;

        private bool paused = false;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            GameManager.Instance.GamePaused += OnPause;
            GameManager.Instance.GameUnpaused += OnUnPause;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Interfaces.ITakeDamage>() != null)
            {
                collision.gameObject.GetComponent<Interfaces.ITakeDamage>().TakeDamage(bulletController.bulletModel.Damage);
            }

            if (collision.gameObject.GetComponent<Bullet.BulletView>() == null)
                DestroyBullet();
        }

        private void Update()
        {
            if(paused == false)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= destroyTime)
                    DestroyBullet();
            }
        }

        public void MoveBullet(Vector3 direction, float force, float destroyTime)
        {
            rb.AddForce(direction * force, ForceMode.Impulse);
            this.destroyTime = destroyTime;
        }

        private void DestroyBullet()
        {
            GameManager.Instance.GamePaused -= OnPause;
            GameManager.Instance.GameUnpaused -= OnUnPause;
            bulletController.DestroyController();
            Destroy(gameObject);
        }

        private void OnPause()
        {
            lastVelocity = rb.velocity;
            rb.isKinematic = true;
            paused = true;
        }

        private void OnUnPause()
        {
            rb.isKinematic = false;
            rb.velocity = lastVelocity;
            paused = false;
        }

    }
}