using System;
using UnityEngine;

namespace Tank
{
    public class PlayerTankController : TankController
    {
        #region Public Events

        public event Action<float> DecreaseHealth;
        public event Action LoseLife;
        public event Action PlayerDied;

        #endregion

        #region Private Data Members

        private Rigidbody _rigidbody;
        private Vector2 _joystickDirection;
        private bool _firing;

        #endregion

        #region Private Functions

        private void TakeJoystickInputs()
        {
            _joystickDirection = ((PlayerTankView)TankView).InputSystem.Joystick.Direction;
        }

        private async void DieOnce()
        {
            TankView.gameObject.SetActive(false);
            await ((Interfaces.ITankService) PlayerTankService.Instance).Explode(PlayerTankService.Instance.Player,
                PlayerTankService.Instance.Explosion);
            TankView.transform.position = PlayerTankService.Instance.GetSafePosition();
            TankView.gameObject.SetActive(true);
        }

        #endregion

        #region Constructors

        public PlayerTankController(InputSystem.InputSystem inputSystem, Scriptable_Object.Tank.Tank tank):base(tank.TankView)
        {
            ((PlayerTankView)TankView).SetInputSystem(inputSystem);
            _rigidbody = TankView.GetComponent<Rigidbody>();
            TankModel = new PlayerTankModel((PlayerTankModel)tank.TankModel);
            
            LoseLife += DieOnce;
        }

        #endregion

        #region Protected Functions

        protected override void DestroyMe()
        {
            PlayerTankService.Instance.Destroy();
        }

        #endregion

        #region Public Functions

        public void Move()
        {
            TakeJoystickInputs();
            Vector3 newForward =(_joystickDirection.magnitude<0.2f)?TankView.transform.forward:new Vector3(_joystickDirection.x , 0, _joystickDirection.y );
            newForward = (newForward*TankModel.Speed).normalized;
            TankView.transform.forward = newForward;
            if(_joystickDirection.magnitude>0.02f)TankView.transform.eulerAngles += Vector3.up * 60;
            Vector3 newVelocity = TankModel.Speed * _joystickDirection.magnitude * TankView.transform.forward;
            _rigidbody.velocity = newVelocity;
        }

        public void HandleAttacks()
        {
            if (((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing == false)
            {
                Attack.Attack attack = new Attack.LinearAttack(TankModel.Bullet, TankView.ShootingPoint.position, TankModel.Damage, TankView.transform.forward,TankModel.TankType);
                Bullet.BulletService.Instance.CreateBullet(attack);
                _firing = true;
            }
            else if (!((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing) _firing = false;
        }
        
        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            DecreaseHealth.Invoke(((PlayerTankModel)TankModel).CurrentHealth/TankModel.Health);
            if (((PlayerTankModel)TankModel).CurrentHealth<= 0)
            {
                ((PlayerTankModel)TankModel).DecreaseLives();
                if (((PlayerTankModel) TankModel).Lives <= 0)
                {
                    PlayerDied.Invoke();
                    DestroyMe();
                    return;
                }

                LoseLife.Invoke();
                ((PlayerTankModel)TankModel).ResetCurrentHealth();
            }
            
        }

        #endregion
    }
}