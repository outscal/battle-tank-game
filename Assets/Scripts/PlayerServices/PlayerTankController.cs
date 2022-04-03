using UnityEngine;
using BulletServices;
using GameplayServices;
using UIServices;

namespace PlayerTankServices
{
    public class PlayerTankController
    {
        public PlayerTankModel tankModel { get; }
        public PlayerTankView tankView { get; }
        private Rigidbody tankRigidbody;
        private Joystick rightJoystick;
        private Joystick leftJoystick;
        private Camera mainCamera;

        public PlayerTankController(PlayerTankModel tankModel, PlayerTankView tankPrefab)
        {
            this.tankModel = tankModel;
            tankView = GameObject.Instantiate<PlayerTankView>(tankPrefab, SpawnPointService.Instance.GetPlayerSpawnPoint());
            tankRigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankControllerReference(this);
        }

        public void SetJoystickReference(Joystick rightRef, Joystick leftRef)
        {
            rightJoystick = rightRef;
            leftJoystick = leftRef;
        }

        public void SetCameraReference(Camera cameraRef)
        {
            mainCamera = cameraRef;
        }

        public void UpdateTankController()
        {
            PlayEngineAudio();
        }

        public void FixedUpdateTankController()
        {
            ForwardMovement();
            if (tankView.tankHead)
            {
                if (rightJoystick.Horizontal != 0)
                {
                    TurretRotation();
                }
            }
        }

        private void ForwardMovement()
        {
            if (Mathf.Abs(leftJoystick.Horizontal) > 0.2f || Mathf.Abs(leftJoystick.Vertical) > 0.2F)
            {
                Vector3 forwardInput = new Vector3(leftJoystick.Horizontal, 0, leftJoystick.Vertical);
                forwardInput.Normalize();

                tankView.transform.Translate(forwardInput * tankModel.speed * Time.deltaTime, Space.World);
                tankView.transform.forward = forwardInput;
            }
        }

        private void TurretRotation()
        {
            Vector3 desiredRotation = Vector3.up * rightJoystick.Horizontal * tankModel.turretRotationRate * Time.deltaTime;

            tankView.tankHead.transform.Rotate(desiredRotation, Space.Self);
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
            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(false);
            }
        }

        public void SetAimUI()
        {
            tankView.aimSlider.value = tankModel.currentLaunchForce;
        }

        private void Death()
        {
            tankModel.b_IsDead = true;

            tankView.explosionParticles.transform.position = tankView.transform.position;
            tankView.explosionParticles.gameObject.SetActive(true);
            tankView.explosionParticles.Play();
            tankView.explosionSound.Play();

            mainCamera.transform.parent = null;

            tankView.Death();

            GameManager.Instance.DestroyAllGameObjects();
        }

        private void PlayEngineAudio()
        {
            if (leftJoystick.Vertical != 0 || leftJoystick.Horizontal != 0)
            {
                if (tankView && tankView.movementAudio.clip == tankView.engineIdling)
                {
                    tankView.movementAudio.clip = tankView.engineDriving;
                    tankView.movementAudio.Play();
                }
            }
            else
            {
                if (tankView && tankView.movementAudio.clip == tankView.engineDriving)
                {
                    tankView.movementAudio.clip = tankView.engineIdling;
                    tankView.movementAudio.Play();
                }
            }
        }

        public void SubscribeEvents()
        {
            EventHandler.Instance.OnBulletFired += FiredBullet;
        }

        public void UnsubscribeEvents()
        {
            EventHandler.Instance.OnBulletFired -= FiredBullet;
        }

        public void FiredBullet()
        {
            tankModel.b_IsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();

            tankModel.currentLaunchForce = tankModel.minLaunchForce;

            tankModel.BulletsFired++;
            AchievementSystem.Instance.BulletsFiredCountCheck(tankModel.BulletsFired);
            EventHandler.Instance.InvokeOnBulletFired();
        }  
    }
}
