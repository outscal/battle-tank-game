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
            Vector3 movement = TankModel.TankSpeed * TankView.playerMoveVertical * Time.deltaTime * TankView.transform.forward;
            TankView.rb.MovePosition(TankView.rb.position + movement);
        }
        public void PlayerTankRotation()
        {
            float turn;
            if (TankView.playerMoveVertical != 0)
            {
                turn = TankView.playerMoveVertical * TankView.playerTurnHorizontal * TankModel.TankTurnSpeed * Time.deltaTime;
            }
            else
            {
                turn = TankView.playerTurnHorizontal * TankModel.TankTurnSpeed * Time.deltaTime;
            }
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            TankView.rb.MoveRotation(TankView.rb.rotation * turnRotation);
        }

        internal void StartFunction()
        {
            TankModel.ChargeSpeed = (TankModel.MaxLaunchForce - TankModel.MinLaunchForce) / TankModel.MaxChargeTime;
        }

        public void OnEnableFunction()
        {
            TankModel.CurrentLaunchForce = TankModel.MinLaunchForce;
            TankView.aimSlider.value = TankModel.MinLaunchForce;
            TankModel.currentHealth = TankModel.TankHealth;
            TankView.tankDead = false;
            SetHealthUI();
            //TankView.m_ChargeSpeed = (TankView.m_MaxLaunchForce - TankView.m_MinLaunchForce) / TankView.m_MaxChargeTime;
        }
        private void SetHealthUI()
        {
            TankView.sliderHealth.value = TankModel.currentHealth;
            TankView.fillImage.color = Color.Lerp(TankView.zeroHealthColor, TankView.fullHealthColor, TankModel.currentHealth / TankModel.TankHealth);
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
            TankView.Destroy(TankView.gameObject);
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
            TankView.aimSlider.value = TankModel.MinLaunchForce;

            if (TankModel.CurrentLaunchForce >= TankModel.MaxLaunchForce && !TankView.fired)
            {
                TankModel.CurrentLaunchForce = TankModel.MaxLaunchForce;
                Fire();
            }
            else if (TankView.fire1)
            {
                TankView.fired = false;
                TankModel.CurrentLaunchForce = TankModel.MinLaunchForce;

                // Change the clip to the charging clip and start it playing.
                //TankView.m_ShootingAudio.clip = TankView.m_ChargingClip;
                //TankView.m_ShootingAudio.Play();
            }
            else if (TankView.fire0 && !TankView.fired)
            {
                TankModel.CurrentLaunchForce += TankModel.ChargeSpeed * Time.deltaTime;

                TankView.aimSlider.value = TankModel.CurrentLaunchForce;
            }
            else if (TankView.fire3 && !TankView.fired)
            {
                Fire();
            }
        }

        private void Fire()
        {
            TankView.fired = true;

            Rigidbody shellInstance = GameObject.Instantiate(TankView.shellPrefab, TankView.fireTransform.position, TankView.fireTransform.rotation) as Rigidbody;

            shellInstance.velocity = TankModel.CurrentLaunchForce * TankView.fireTransform.forward; ;

            // Change the clip to the firing clip and play it.
            //TankView.m_ShootingAudio.clip = TankView.m_FireClip;
            //TankView.m_ShootingAudio.Play();

            TankModel.CurrentLaunchForce = TankModel.MinLaunchForce;
        }
    }
}