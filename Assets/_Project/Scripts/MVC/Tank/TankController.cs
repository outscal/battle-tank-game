using UnityEngine;
namespace Tanks.MVC
{
    public class TankController
    {

        public TankModel TankModel { get; }
        public TankView TankView { get; }
        public TankController()
        {
            TankView.tankController = this;
        }
        public TankController(TankModel tankModel, TankView tankPrefab, Vector3 spawnPlayer)
        {
            TankModel = tankModel;
            TankView = Object.Instantiate(tankPrefab);
            Debug.Log("Tank View Created", TankView);
            TankView.tankController = this;
            tankPrefab.transform.position = spawnPlayer;
            OnEnableFunction();
        }

        public void PlayerTankMovement()
        {
            Vector3 movement = TankModel.tankSpeed * TankView.playerMoveVertical * Time.deltaTime * TankView.transform.forward;
            TankView.rb.MovePosition(TankView.rb.position + movement);
        }
        public void PlayerTankRotation()
        {
            float turn;
            if (TankView.playerMoveVertical != 0)
            {
                turn = TankView.playerMoveVertical * TankView.playerTurnHorizontal * TankModel.tankTurnSpeed * Time.deltaTime;
            }
            else
            {
                turn = TankView.playerTurnHorizontal * TankModel.tankTurnSpeed * Time.deltaTime;
            }
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            TankView.rb.MoveRotation(TankView.rb.rotation * turnRotation);
        }

        public void OnEnableFunction()
        {
            TankView.currentHealth = TankModel.tankHealth;
            TankView.tankDead = false;

            SetHealthUI();
        }
        private void SetHealthUI()
        {
            TankView.sliderHealth.value = TankView.currentHealth;
            TankView.fillImage.color = Color.Lerp(TankView.zeroHealthColor, TankView.fullHealthColor, TankView.currentHealth / TankModel.tankHealth);
        }

        public void TakeDamage(float amount)
        {
            TankView.currentHealth -= amount;

            SetHealthUI();

            if (TankView.currentHealth <= 0f && !TankView.tankDead)
            {
                OnDeath();
            }
        }
        private void OnDeath()
        {
            TankView.tankDead = true;
            TankView.gameObject.SetActive(false);
        }

        public void CheckDamage()
        {
            if (!TankView.tankDead && TankView.fire)
            {
                TakeDamage(10);
            }
        }
    }
}