using System;
using Attack;
using Bullet;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Tank
{
    public class PlayerTankController : TankController
    {
        public event Action<float> DecreaseHealth = delegate(float f) {  };
        public event Action LoseLife = delegate {  };
        
        public event Action PlayerDied = delegate {  };
        
        private Rigidbody _rigidbody;
        private Vector2 _joystickDirection;

        private bool _firing;
    
        void TakeJoystickInputs()
        {
            _joystickDirection = ((PlayerTankView)TankView).InputSystem.Joystick.Direction;
        }
        public override void Move()
        {
            TakeJoystickInputs();
            Vector3 newForward =(_joystickDirection.magnitude<0.2f)?TankView.transform.forward:new Vector3(_joystickDirection.x , 0, _joystickDirection.y );
            newForward = (newForward*TankModel.Speed).normalized;
            TankView.transform.forward = newForward;
            if(_joystickDirection.magnitude>0.02f)TankView.transform.eulerAngles += Vector3.up * 60;
            Vector3 newVelocity = TankModel.Speed * _joystickDirection.magnitude * TankView.transform.forward;
            _rigidbody.velocity = newVelocity;
        }
        
        public override void HandleAttacks()
        {
            if (((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing == false)
            {
                Debug.Log("Firing");
                Attack.Attack attack = new LinearAttack(TankModel.BulletType, TankView.ShootingPoint.position, TankModel.Damage, TankView.transform.forward);
                BulletService.Instance.CreateBullet(attack);
                _firing = true;
            }
            else if (!((PlayerTankView)TankView).InputSystem.FireButton.Pressed && _firing) _firing = false;
        }
        
        public PlayerTankController(InputSystem.InputSystem inputSystem, Scriptable_Object.Tank.Tank tank):base(tank.TankView)
        {
            ((PlayerTankView)TankView).SetInputSystem(inputSystem);
            _rigidbody = TankView.GetComponent<Rigidbody>();
            TankModel = new PlayerTankModel((PlayerTankModel)tank.TankModel);
            
            LoseLife += DieOnce;
        }
        

        protected override void DestroyMe()
        {
            PlayerTankService.Instance.Destroy();
        }

        public override void HitBy(Collision collision)
        {
            base.HitBy(collision);
            if(collision.gameObject.GetComponent<EnemyTankView>()) {TakeDamage(collision.gameObject.GetComponent<EnemyTankView>().TankController.TankModel.Damage);}
        }

        public override void TakeDamage(float amount)
        {
            base.TakeDamage(amount);
            DecreaseHealth.Invoke(((PlayerTankModel)TankModel).CurrentHealth/TankModel.Health);
            if (((PlayerTankModel)TankModel).CurrentHealth<= 0)
            {
                ((PlayerTankModel)TankModel).DecreaseLives();
                LoseLife.Invoke();
                if (((PlayerTankModel) TankModel).Lives <= 0)
                {
                    PlayerDied.Invoke();
                    DestroyMe();
                    return;
                }
                ((PlayerTankModel)TankModel).ResetCurrentHealth();
            }
            
        }

        private void DieOnce()
        {
            Debug.Log("Died once");
            TankView.transform.position = PlayerTankService.Instance.GetSafePosition();
        }
    }
}