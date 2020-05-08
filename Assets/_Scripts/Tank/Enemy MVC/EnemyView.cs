using System;
using Bullet.View;
using Enemy.AttackingState;
using Enemy.ChasingState;
using Enemy.Controller;
using Enemy.DeathState;
using Enemy.PatrolingState;
using Enemy.State;
using Idamagable;
using Tank.View;
using UnityEngine;

namespace Enemy.View
{
    public class EnemyView : MonoBehaviour, IDamagable
    {
        EnemyController enemyController;
        public ParticleSystem TankExplosion;

        private EnemyTankState currentState;
        private Renderer enemyTankRenderer;

        [SerializeField]
        private float chaseRadius = 25f;
        [SerializeField]
        private float attackRadius = 8f;

        //[SerializeField]
        //private EnemyTankState defaultState;

        public void SetEnemyController(EnemyController ec)
        {
            enemyController = ec;
        }


        private void Start()
        {
            //SetState(defaultState);
            enemyTankRenderer = GetComponent<Renderer>();
            SetState(new EnemyPatrolingState(this)); // default state - patroling state
        }

        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.T))
            //{
            //    enemyController.FireBullet(transform.position, transform.eulerAngles);
            //}

            currentState.Tick();

        }

        private void SetState(EnemyTankState enemyTankState)
        {
            if (currentState != null)
            {
                currentState.OnStateExit();
            }

            currentState = enemyTankState;

            if (currentState != null)
            {
                currentState.OnStateEnter();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.GetComponent<TankView>() != null)
            {
                if (IsInChaseRadius(other)){
                    SetState(new EnemyChasingState(this));
                }
                if (IsInAttackRadius(other))
                {
                    SetState(new EnemyAttackingState(this));
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<TankView>() != null)
            {
                if (!IsInChaseRadius(other))
                {
                    SetState(new EnemyPatrolingState(this));
                }
                else if (!IsInAttackRadius(other))
                {
                    SetState(new EnemyChasingState(this));
                }
            }
        }

        private bool IsInChaseRadius(Collider other)
        {
            return (((Vector3.Distance(other.gameObject.transform.position, transform.position)) - 1.25f < chaseRadius) && ((Vector3.Distance(other.gameObject.transform.position, transform.position)) - 1.25f > attackRadius));
        }

        private bool IsInAttackRadius(Collider other)
        {
            return ((Vector3.Distance(other.gameObject.transform.position, transform.position)) - 1.25f < attackRadius);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<BulletView>() != null)
            {
                enemyController.DestroyEnemyTank();
                SetState(new EnemyDeathState(this));
            }
        }

        public void DestroyEnemyTankPrefab()
        {
            Destroy(gameObject);
        }

        public void InstantiateTankExplosionParticleEffect()
        {
            Instantiate(TankExplosion, transform.position, new Quaternion(0f, 0f, 0f, 0f));
        }

        public void TakeDamage()
        {
            //implementation
        }
    }
}