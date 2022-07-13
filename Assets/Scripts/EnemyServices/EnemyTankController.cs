using GameplayServices;
using GlobalServices;
using System;
using UnityEngine;

namespace EnemyTankServices
{
    // Handles all behaviour of enemy tank. // Brain of enemy tank.
    public class EnemyTankController
    {
        public EnemyTankModel tankModel { get; }
        public EnemyTankView tankView { get; }
     
        public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
        {
            this.tankModel = tankModel;

            // Spawns enemy tank at random position.
            Transform tranform = SpawnPointService.Instance.GetRandomSpawnPoint();
            tankView = GameObject.Instantiate<EnemyTankView>(tankPrefab, tranform.position, tranform.rotation);
            tankView.tankController = this;
        }

        public void EnableTankView()
        {
            tankView.gameObject.SetActive(true);
            tankModel.b_IsDead = false;
        }

        public void DisableTankView()
        {
            tankView.gameObject.SetActive(false);
            tankModel.b_IsDead = true;
        }

        // This method is called on every fixed update. // To do all physics calculations.
        public void UpdateTankController()
        {
            // Checks whether the player is in sight range or attack range.
            tankModel.b_PlayerInSightRange = Physics.CheckSphere(tankView.transform.position, tankModel.patrollingRange, tankView.playerLayerMask);
            tankModel.b_PlayerInAttackRange = Physics.CheckSphere(tankView.transform.position, tankModel.attackRange, tankView.playerLayerMask);
        }

        // Reduce current health by the amount of damage done.
        public void TakeDamage(int damage)
        {
            tankModel.health -= damage;
            SetHealthUI();
            ShowHealthUI();

            // If health goes below zero, tank dies.
            if (tankModel.health <= 0 && !tankModel.b_IsDead)
            {
                Death();
            }
        }

        // Update the health slider's value and color.
        public void SetHealthUI()
        {
            tankView.healthSlider.value = tankModel.health;

            // Interpolate the color of the health bar between the choosen colours based on the current percentage of the health.
            tankView.fillImage.color = Color.Lerp(tankModel.zeroHealthColor, tankModel.fullHealthColor, tankModel.health / tankModel.maxHealth);
        }

        // Enables health UI and disables after certain interval of time.
        async public void ShowHealthUI()
        {
            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(true);
            }

            await new WaitForSeconds(3f);

            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(false);
            }
        }

        public void Death()
        {
            tankModel.b_IsDead = true;

            // Move the instantiated explosion prefab to the tank's position and turn it on.
            tankView.explosionParticles.transform.position = tankView.transform.position;
            tankView.explosionParticles.gameObject.SetActive(true);

            tankView.explosionParticles.Play();
            tankView.explosionSound.Play();

            tankView.Death();

            EnemyTankService.Instance.DestroyEnemy(this);
            EventService.Instance.InvokeOnEnemyDeathEvent();
        }
    }
}
