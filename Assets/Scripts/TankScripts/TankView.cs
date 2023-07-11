using UnityEngine;
using BattleTank.Enemy;

namespace BattleTank.PlayerTank
{
    public class TankView : MonoBehaviour, IDamageable
    {
        private TankController tankController;

        private float horizontalMove;
        private float verticalMove;

        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform gun;
        [SerializeField] private FixedJoystick joystick;

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public void SetJoystick(FixedJoystick _joystick)
        {
            joystick = _joystick;
        }

        public Rigidbody GetRigidbody()
        {
            return rb;
        }

        void PlayerInput()
        {
            horizontalMove = joystick.Horizontal;
            verticalMove = joystick.Vertical;
        }

        void Update()
        {
            PlayerInput();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.Shoot(gun);
            }

            if (horizontalMove != 0 || verticalMove != 0)
            {
                tankController.MoveTank(horizontalMove, verticalMove);
            }
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.GetComponent<EnemyView>() != null)
            {
                EnemyView enemyView = col.gameObject.GetComponent<EnemyView>();
                tankController.TakeDamage(enemyView.GetEnemyStrength());
            }
        }

        void IDamageable.TakeDamage(int damage, TankType tankType)
        {
            if (tankType == TankType.Enemy)
                tankController.TakeDamage(damage);
        }
    }
}
