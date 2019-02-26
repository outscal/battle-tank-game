using UnityEngine;
using Bullet;
using Interfaces;
using StateMachine;
using Manager;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour, ITakeDamage
    {
        private PlayerController playerController;

        [SerializeField]
        private GameObject bulletSpawnPos;
        [SerializeField] private Camera playerCam;

        private IGameManager gameManager;
        public Camera PlayerCam { get { return playerCam; } }

        public GameObject BulletSpawnPos
        {
            get { return bulletSpawnPos; }
        }

        private void Start()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();
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
            if (gameManager.GetCurrentState().gameStateType == GameStateType.Pause) return;
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
            playerCam.transform.parent = null;
            PlayerManager.Instance.DestroyPlayer(playerController);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage, int shooterID)
        {
            Debug.Log("Dont shoot friends");
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.up, PlayerManager.Instance.safeRadius);
        }
#endif

    }
}
	