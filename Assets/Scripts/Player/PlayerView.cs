using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using UI;
using Interfaces;
using StateMachine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour, ITakeDamage
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

        void Update()
        {
            foreach (CharacterState state in playerController.playerStates.Keys)
            {
                bool isActive;
                playerController.playerStates.TryGetValue(state, out isActive);
                if(isActive)
                {
                    state.OnUpdate();
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                playerController.setTakeDamageState();
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

        public void TakeDamage(int damage)
        {
            Debug.Log("Dont shoot friends");
        }
#endif

    }
}
	