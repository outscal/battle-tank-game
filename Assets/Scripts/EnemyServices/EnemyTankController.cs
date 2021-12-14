using UnityEngine;
using BulletServices;

namespace EnemyTankServices
{
    public class EnemyTankController
    {
        public EnemyTankModel tankModel { get; }
        public EnemyTankView tankView { get; }
     
        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
        {
            this.tankModel = tankModel;
            tankView = GameObject.Instantiate<EnemyTankView>(tankPrefab, new Vector3(3,0,-3), new Quaternion(0,0,0,0));
            tankView.tankController = this;
        }

        public void UpdateTankController()
        {
            tankModel.b_PlayerInSightRange = Physics.CheckSphere(tankView.transform.position, tankModel.patrollingRange, tankView.playerLayerMask);
            tankModel.b_PlayerInAttackRange = Physics.CheckSphere(tankView.transform.position, tankModel.attackRange, tankView.playerLayerMask);

            if (!tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) Patroling();
            if (tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) ChasePlayer();
            if (tankModel.b_PlayerInSightRange && tankModel.b_PlayerInAttackRange) AttackPlayer();    
        }

        private void Patroling()
        {
            if (!tankModel.b_IsWalkPoint) SearchWalkPoint();

            if(tankModel.b_IsWalkPoint)
            {
                tankView.navAgent.SetDestination(tankModel.walkPoint);
            }

            Vector3 distanceToWalkPoint = tankView.transform.position - tankModel.walkPoint;

            if(distanceToWalkPoint.magnitude < 1f)
            {
                tankModel.b_IsWalkPoint = false;
            }
        }

        public async void ChangeWalkPoint()
        {
            while(true)
            {
                await new WaitForSeconds(tankModel.patrolTime);
                tankModel.b_IsWalkPoint = false;
            }
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);
            float randomX = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);

            tankModel.walkPoint = new Vector3(tankView.transform.position.x + randomX, tankView.transform.position.y, tankView.transform.position.z + randomZ);

            if(Physics.Raycast(tankModel.walkPoint, -tankView.transform.up, 2f, tankView.groundLayerMask))
            {
                tankModel.b_IsWalkPoint = true;
            }
        }

        private void ChasePlayer()
        {
            tankView.navAgent.SetDestination(tankView.playerTransform.position);

            if (tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y > 1 
                || tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y < -1)
            {
                Vector3 desiredRotation = Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
                tankView.turret.transform.Rotate(desiredRotation, Space.Self);
            }
        }

        private async void AttackPlayer()
        {
            tankView.navAgent.SetDestination(tankView.transform.position);

            Vector3 forward = tankView.turret.transform.TransformDirection(Vector3.forward);
            Vector3 desiredRotation = new Vector3(0,0,0);

            if (!Physics.Raycast(tankView.transform.position, forward, tankModel.attackRange, tankView.playerLayerMask))
            {
                Vector3 targetDir = tankView.playerTransform.position - tankView.turret.transform.position;
                float angle = Vector3.SignedAngle(targetDir, tankView.turret.transform.forward, Vector3.up);

                if (angle < 0)
                {
                    desiredRotation = Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
                }
                else if(angle > 0)
                {
                    desiredRotation = -Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
                }

                tankView.turret.transform.Rotate(desiredRotation, Space.Self);    
            }

            else if (!tankModel.b_IsFired)
            {
                tankModel.b_IsFired = true;
                FireBullet();
                await new WaitForSeconds(tankModel.fireRate);
                ResetAttack();
            }
        }

        public void FireBullet()
        {
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankView.GetRandomLaunchForce());

            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();
        }

        private void ResetAttack()
        {
            tankModel.b_IsFired = false;
        }

        public void TakeDamage(int damage)
        {
            tankModel.health -= damage;
            SetHealthUI();

            if (tankModel.health <= 0 && !tankModel.b_IsDead)
            {
                Death();
            }
        }

        public void SetHealthUI()
        {
            tankView.healthSlider.value = tankModel.health;

            tankView.fillImage.color = Color.Lerp(tankModel.zeroHealthColor, tankModel.fullHealthColor, tankModel.health / tankModel.maxHealth);
        }

        private void Death()
        {
            tankModel.b_IsDead = true;

            tankView.explosionParticles.transform.position = tankView.transform.position;
            tankView.explosionParticles.gameObject.SetActive(true);
            tankView.explosionParticles.Play();
            tankView.explosionSound.Play();

            tankView.Death();
        }
    }
}
