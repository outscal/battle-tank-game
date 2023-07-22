using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BattleTank
{
    public class TankView : MonoBehaviour, IDamageable
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform bulletSpawnPoint;
        [SerializeField] private Transform tankBody;
        private TankController tankController;
        public Transform GetBulletSpawnPoint() => bulletSpawnPoint;
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            CameraFollow();
        }
        private void CameraFollow()
        {
            GameObject gameObject1 = GameObject.Find("Main Camera");
            GameObject cam = gameObject1;
            cam.transform.SetParent(transform);
            cam.transform.position = new Vector3(0f, 12f, -15);
            cam.transform.rotation *= Quaternion.Euler(40f, 0f, 0f);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.Shoot(bulletSpawnPoint);
            }
        }
        private void FixedUpdate()
        {
            tankController.TankMove();
        }
        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }
        public Rigidbody GetRigidbody()
        {
            return rb;
        }
        public Transform GetTransform()
        {
            return transform;
        }
        public Transform GetTankBody()
        {
            return tankBody;
        }
        void IDamageable.TakeDamage(int Damage)
        {
            tankController.TakeDamage(Damage);
        }
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<EnemyView>() != null)
            {
                EnemyView enemyView = col.gameObject.GetComponent<EnemyView>();
                tankController.TakeDamage(enemyView.GetEnemyStrength());
            }
        }
    }
}