using UnityEngine;
using Manager;
using Interfaces;

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
        public int shooterID;

        private IGameManager gameManager;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            gameManager.GamePaused += OnPause;
            gameManager.GameUnpaused += OnUnPause;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Interfaces.ITakeDamage>() != null)
            {
                collision.gameObject.GetComponent<Interfaces.ITakeDamage>().TakeDamage(bulletController.bulletModel.Damage, shooterID);
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
            gameManager.GamePaused -= OnPause;
            gameManager.GameUnpaused -= OnUnPause;
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