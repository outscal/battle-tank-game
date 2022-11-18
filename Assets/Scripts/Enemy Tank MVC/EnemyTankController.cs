using GameServices;
using UnityEngine;
using UIServices;
using AllServices;
using EffectServices;

namespace EnemyTankServices
{
    public class EnemyTankController
    {
        public EnemyTankModel enemyTankModel { get; }
        public EnemyTankView enemyTankView { get; }

        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView enemyTankPrefab)
        {
            enemyTankModel = tankModel;

            // Spawns enemy tank at random position.
            Transform tranform = TankSpawnPointService.Instance.GetRandomSpawnPoint();
            enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTankPrefab, tranform.position, tranform.rotation);
            enemyTankView.enemyTankController = this;
        }

        public void EnableTankView()
        {
            enemyTankView.gameObject.SetActive(true);
            enemyTankModel.b_IsEnemyTankDead = false;
        }

        public void DisableTankView()
        {
            enemyTankView.gameObject.SetActive(false);
            enemyTankModel.b_IsEnemyTankDead = true;
        }

        // To do all physics calculations.
        public void RangeCheck()
        {
            enemyTankModel.b_PlayerInSightRange = Physics.CheckSphere(enemyTankView.transform.position, enemyTankModel.patrollingRange, enemyTankView.playerLayerMask);
            enemyTankModel.b_PlayerInAttackRange = Physics.CheckSphere(enemyTankView.transform.position, enemyTankModel.attackRange, enemyTankView.playerLayerMask);
        }

        public void TakeDamage(int damage)
        {
            enemyTankModel.health -= damage;
            SetHealthUI();
            ShowHealthUI();

            if (enemyTankModel.health <= 0 && !enemyTankModel.b_IsEnemyTankDead)
            {
                Death();
            }
        }

        // Update the health slider's value and color.
        public void SetHealthUI()
        {
            enemyTankView.healthSlider.value = enemyTankModel.health;
            enemyTankView.fillImage.color = Color.Lerp(enemyTankModel.zeroHealthColor, enemyTankModel.fullHealthColor, enemyTankModel.health / enemyTankModel.maxHealth);
        }

        // Enables health UI and disables after certain interval of time.
        async public void ShowHealthUI()
        {
            if (enemyTankView)
            {
                enemyTankView.healthSlider.gameObject.SetActive(true);
            }

            await new WaitForSeconds(3f);

            if (enemyTankView)
            {
                enemyTankView.healthSlider.gameObject.SetActive(false);
            }
        }

        public void Death()
        {
            enemyTankModel.b_IsEnemyTankDead = true;

            // Move the instantiated explosion prefab to the tank's position and turn it on.
            enemyTankView.explosionParticles.transform.position = enemyTankView.transform.position;
            enemyTankView.explosionParticles.gameObject.SetActive(true);

            enemyTankView.explosionParticles.Play();

            EnemyTankService.Instance.DestroyEnemy(this);
            enemyTankView.Death();

            EventService.Instance.InvokeOnEnemyDeathEvent();

            UIHandler.Instance.GameWonUI(true);
        }
    }
}
