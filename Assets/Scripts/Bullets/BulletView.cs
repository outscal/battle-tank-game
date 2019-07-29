using UnityEngine;
using Manager;
using Interfaces;
using Extensions;

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
            if (collision.gameObject.GetComponent<ITakeDamage>() != null)
            {
                collision.gameObject.GetComponent<ITakeDamage>().TakeDamage(bulletController.bulletModel.Damage, shooterID);
            }

            if (collision.gameObject.GetComponent<BulletView>() == null)
                bulletController.Reset();
        }

        private void Update()
        {
            if(paused == false)
            {
                currentTime += Time.deltaTime;
                if (currentTime >= destroyTime)
                    bulletController.Reset();
            }
        }

        public void MoveBullet(Vector3 direction, float force, float destroyTime)
        {
            rb.AddForce(direction * force, ForceMode.Impulse);
            this.destroyTime = destroyTime;
        }

        public void ResetBulletView()
        {
            gameManager.GamePaused -= OnPause;
            gameManager.GameUnpaused -= OnUnPause;
            currentTime = 0;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            //Destroy(gameObject);
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