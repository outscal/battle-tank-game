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
            tankView = GameObject.Instantiate<EnemyTankView>(tankPrefab, new Vector3(3, 0, -3), new Quaternion(0, 0, 0, 0));

            tankView.tankController = this;
        }

        public void UpdateTankController()
        {
            tankModel.b_PlayerInSightRange = Physics.CheckSphere(tankView.transform.position, tankModel.patrollingRange, tankView.playerLayerMask);
            tankModel.b_PlayerInAttackRange = Physics.CheckSphere(tankView.transform.position, tankModel.attackRange, tankView.playerLayerMask);
        }

        public void TakeDamage(int damage)
        {
            tankModel.health -= damage;
            SetHealthUI();
            ShowHealthUI();

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

        public void ShowHealthUI()
        {
            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(true);
            }
        }

        public void Death()
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
