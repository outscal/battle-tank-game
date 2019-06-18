using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using UI;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {

        private PlayerController playerController;

        [SerializeField]
        private GameObject bulletSpawnPos;

        public GameObject BulletSpawnPos
        {
            get { return bulletSpawnPos; }
        }


        public void SetController(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public void MoveTank(float hVal, float vVal, float speed, float rotateSpeed)
        {
            transform.Translate(vVal * Vector3.forward * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, hVal, 0) * rotateSpeed);
        }

        public void Shoot(BulletController bulletController)
        {
            bulletController.SpawnBullet(transform.forward, bulletSpawnPos.transform.position, transform.eulerAngles, playerController);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                playerController.TakeDamage(playerController.playerModel.Health);
            }
        }

        public void PlayerDie()
        {
            PlayerManager.Instance.DestroyPlayer(playerController);
            Destroy(gameObject);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, PlayerManager.Instance.safeRadius);
        }
#endif

    }
}
	