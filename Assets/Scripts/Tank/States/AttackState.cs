using System;
using Attack;
using Bullet;
using UnityEngine;

namespace Tank.States
{
    public class AttackState: State
    {
        private TankView _target;
        private float _counter;
        private bool _isInitialized;
        
        public TankView Target => _target;

        public void Init(TankView target)
        {
            _target = target;
            ResetCounter();
            _isInitialized = true;
        }

        private void OnEnable()
        {
            _tankView.NavMeshAgent.speed *= 0.01f;
        }

        private void ResetCounter()
        {
            _counter = ((EnemyTankModel) _tankView.TankController.TankModel).AiAgentModel.FireRate;
        }

        private void Start()
        {
            if(_target) LunchAttack();
            ((PlayerTankController) _target.TankController).LoseLife += LoseTarget;
        }
        private void Update()
        {
            
            if (!_isInitialized) return;
            if (_counter >= 0)
            {
                _counter -= Time.deltaTime;
                return;
            }
            if (_target)
            {
                LunchAttack();
                ResetCounter();
            }
            
        }

        private void LoseTarget()
        {
            _tankView.AttackTargetLost();
        }

        private void LunchAttack()
        {
            Attack.Attack attack = null;
            TrajectoryType attackTrajectory = _tankView.TankController.TankModel.Bullet.BulletModel.TrajectoryType;
            TankModel tankModel = _tankView.TankController.TankModel;
            switch (attackTrajectory)
            {
                case TrajectoryType.Linear:
                    Vector3 direction = _target.transform.position - _tankView.transform.position;
                    attack = new LinearAttack(tankModel.Bullet, _tankView.FiringPoint.position, tankModel.Damage, direction,_tankView.TankController.TankModel.TankType);
                    break;
                case TrajectoryType.Tracking:
                    attack = new TrackingAttack(tankModel.Bullet, _tankView.FiringPoint.position,tankModel.Damage, _target, _tankView.TankController.TankModel.TankType);
                    break;
                default:
                    break;
            }

            BulletService.Instance.CreateBullet(attack);
            Debug.Log("attack!!");
        }

        private void OnDisable()
        {
            _isInitialized = false;
            _tankView.NavMeshAgent.speed *=100;
            ((PlayerTankController) _target.TankController).LoseLife -= LoseTarget;
        }
    }
}