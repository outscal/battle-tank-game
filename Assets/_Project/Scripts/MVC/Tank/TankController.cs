using UnityEngine;
namespace Tanks.MVC
{
    public class TankController
    {
        public TankModel TankModel { get; }
        public TankView TankView { get; }

        public TankController(TankModel tankModel, TankView tankPrefab, Vector3 spawnPlayer)
        {
            TankModel = tankModel;
            TankView = Object.Instantiate(tankPrefab);
            Debug.Log("Tank View Created", TankView);
            TankView.tankController = this;
            tankPrefab.transform.position = spawnPlayer;
            OnEnableFunction();
            //FireControl();
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
            TankView.m_CurrentLaunchForce = TankView.m_MinLaunchForce;
            TankView.m_AimSlider.value = TankView.m_MinLaunchForce;
            TankModel.currentHealth = TankModel.tankHealth;
            TankView.tankDead = false;
            SetHealthUI();
            //TankView.m_ChargeSpeed = (TankView.m_MaxLaunchForce - TankView.m_MinLaunchForce) / TankView.m_MaxChargeTime;
        }
        private void SetHealthUI()
        {
            TankView.sliderHealth.value = TankModel.currentHealth;
            TankView.fillImage.color = Color.Lerp(TankView.zeroHealthColor, TankView.fullHealthColor, TankModel.currentHealth / TankModel.tankHealth);
        }

        public void TakeDamage(float amount)
        {
            TankModel.currentHealth -= amount;

            if (TankModel.currentHealth <= 0f && !TankView.tankDead)
            {
                TankDestroy();
            }
            SetHealthUI();
        }
        private void TankDestroy()
        {
            TankView.tankDead = true;
            TankView.gameObject.SetActive(false);
            Object.Destroy(TankView.gameObject);
        }

        //public void CheckDamage()
        //{
        //    if (!TankView.tankDead && TankView.fire)
        //    {
        //        TakeDamage(10);
        //    }
        //}

        public void FireControl()
        {
            TankView.m_AimSlider.value = TankView.m_MinLaunchForce;

            if (TankView.m_CurrentLaunchForce >= TankView.m_MaxLaunchForce && !TankView.m_Fired)
            {
                TankView.m_CurrentLaunchForce = TankView.m_MaxLaunchForce;
                Fire();
            }
            else if (TankView.fire1)
            {
                TankView.m_Fired = false;
                TankView.m_CurrentLaunchForce = TankView.m_MinLaunchForce;

                // Change the clip to the charging clip and start it playing.
                //TankView.m_ShootingAudio.clip = TankView.m_ChargingClip;
                //TankView.m_ShootingAudio.Play();
            }
            else if (TankView.fire0 && !TankView.m_Fired)
            {
                TankView.m_CurrentLaunchForce += TankView.m_ChargeSpeed * Time.deltaTime;

                TankView.m_AimSlider.value = TankView.m_CurrentLaunchForce;
            }
            else if (TankView.fire3 && !TankView.m_Fired)
            {
                Fire();
            }
        }

        private void Fire()
        {
            TankView.m_Fired = true;

            Rigidbody shellInstance = GameObject.Instantiate(TankView.m_Shell, TankView.m_FireTransform.position, TankView.m_FireTransform.rotation) as Rigidbody;

            shellInstance.velocity = TankView.m_CurrentLaunchForce * TankView.m_FireTransform.forward; ;

            // Change the clip to the firing clip and play it.
            //TankView.m_ShootingAudio.clip = TankView.m_FireClip;
            //TankView.m_ShootingAudio.Play();

            TankView.m_CurrentLaunchForce = TankView.m_MinLaunchForce;
        }
    }
}