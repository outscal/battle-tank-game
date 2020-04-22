using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using BulletSO;
using BulletServices;

namespace EnemyServices
{
    public class EnemyController
    {
        public EnemyModel model { get; private set; }
        public EnemyView view { get; private set; }

        public enum States
        {
            none,
            patrolling,
            following,
            attacking,
        }
        public States currentState;

        private float timer;
        private float canFire = 0f;
        public EnemyController(EnemyView _view, EnemyModel _model)
        {
            model = _model;
            view = GameObject.Instantiate<EnemyView>(_view, GetRandomPosition(), Quaternion.identity);
            model.SetEnemyController(this);
            view.SetEnemyController(this);

        }
        public Vector3 GetRandomPosition()
        {
            Vector3 randDir = Random.insideUnitSphere * model.patrollingRadius;
            randDir += EnemyService.instance.enemy.enemyView.transform.position;
            NavMeshHit navHit;
            NavMesh.SamplePosition(randDir, out navHit, model.patrollingRadius, NavMesh.AllAreas);
            return navHit.position;
        }

        public void Movement()
        {
            if (!view.playerDetected && currentState != States.attacking)
            {
                Patrol();
            }
            else
            {
                Follow();
            }
        }

        public void Attack()
        {
            if (model.attackDist >= Vector3.Distance(view.transform.position, view.GetTank().position))
            {
                currentState = States.attacking;
                if (canFire < Time.time)
                {
                    canFire = model.fireRate + Time.time;
                    BulletService.instance.CreateBullet(view.shootingPoint.position, GetFiringAngle(), model.bullet);
                }
            }
        }

        private Quaternion GetFiringAngle()
        {
            return view.transform.rotation;
        }

        private void Follow()
        {
            currentState = States.following;
            view.navMeshAgent.SetDestination(view.GetTank().position);
        }

        private void Patrol()
        {
            currentState = States.patrolling;
            timer += Time.deltaTime;
            if (timer > model.patrolTime)
            {
                SetPatrolingDestination();
                timer = 0;
            }
        }

        private void SetPatrolingDestination()
        {
            Vector3 newDestination = GetRandomPosition();
            view.navMeshAgent.SetDestination(newDestination);
        }
        public void OnCollisionWithBullet(BulletView bullet)
        {
            EnemyService.instance.DestroyEnemy(this);
            BulletService.instance.DestroyBullet(bullet.bulletController);
        }

        public void DestoryController()
        {
            model.DestroyModel();
            view.DestroyView();


            model = null;
            view = null;
        }
    }
}