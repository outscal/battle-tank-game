using Attack;
using Bullet;
using UnityEngine;

namespace Tank.States
{
    public class AttackState: State
    {
        #region Private Data members

        private TankView _target;
        private float _counter;
        private bool _isInitialized;

        #endregion

        #region Getters

        public TankView Target => _target;

        #endregion

        #region Public Functions

        public void Init(TankView target)
        {
            _target = target;
            ResetCounter();
            _isInitialized = true;
        }

        #endregion

        #region Unity Functions

        private void OnEnable()
        {
            _tankView.NavMeshAgent.speed *= 0.01f;
        }

        private void Start()
        {
            if(_target) LunchAttack();
            PlayerTankService.LoseLife += LoseTarget;
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

        private void OnDisable()
        {
            _isInitialized = false;
            _tankView.NavMeshAgent.speed *=100;
            PlayerTankService.LoseLife -= LoseTarget;
        }

        #endregion

        #region Private Functions

        private void ResetCounter()
        {
            _counter = ((EnemyTankModel) _tankView.TankController.TankModel).AiAgentModel.FireRate;
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

        #endregion
    }
}