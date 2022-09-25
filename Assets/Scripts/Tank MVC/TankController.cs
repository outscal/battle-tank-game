using UnityEngine;
using GameServices;
using BulletServices;
using AchievementServices;
using UIServices;
using EffectServices;
using AllServices;

namespace TankServices
{
    public class TankController
    {
        private Joystick rightJoystick;
        private Joystick leftJoystick;

        private Rigidbody tankRigidbody; // player tank rigidbody reference.

        public TankModel tankModel { get; }
        public TankView tankView { get; }

        private bool b_IsFireButtonPressed = false;

        // model <- controller -> view
        public TankController(TankModel _tankModel, TankView tankPrefab)
        {
            tankModel = _tankModel;
            
            // Spawns player tank.
            tankView = GameObject.Instantiate<TankView>(tankPrefab, TankSpawnPointService.Instance.GetPlayerSpawnPoint());

            tankRigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankControllerReference(this);
            tankModel.SetTankControllerReference(this);

            SubscribeEvents();
        }

        // Sets the reference to joystick on the Canvas.
        public void SetJoystickReference(Joystick _leftJoystick, Joystick _rightJoystick)
        {
            leftJoystick = _leftJoystick;
            rightJoystick = _rightJoystick;
        }

        private void SubscribeEvents()
        {
            EventService.Instance.OnEnemyDeath += UpdateEnemiesKilledCount;
            EventService.Instance.OnplayerFiredBullet += UpdateBulletsFiredCount;
            EventService.Instance.OnFireButtonPressed += FireButtonPressed;
            EventService.Instance.OnFireButtonReleased += FireButtonReleased;
        }

        private void UnsubscribeEvents()
        {
            EventService.Instance.OnEnemyDeath -= UpdateEnemiesKilledCount;
            EventService.Instance.OnplayerFiredBullet -= UpdateBulletsFiredCount;
            EventService.Instance.OnFireButtonPressed -= FireButtonPressed;
            EventService.Instance.OnFireButtonReleased -= FireButtonReleased;
        }

        private void UpdateEnemiesKilledCount()
        {
            tankModel.enemiesKilled += 1;
            PlayerPrefs.SetInt("EnemiesKilled", tankModel.enemiesKilled);
            UIHandler.Instance.UpdateScoreText();
            AchievementHandler.Instance.CheckForEnemiesKilledAchievement();
        }

        private void UpdateBulletsFiredCount()
        {
            tankModel.bulletsFired += 1;
            PlayerPrefs.SetInt("BulletsFired", tankModel.bulletsFired);
            AchievementHandler.Instance.CheckBulletFiredAchievement();
        }

        public void UpdateTankController()
        {
            if (!tankModel.b_IsDead)
            {
                FireBulletInputCheck(); 
                PlayEngineAudio();
            }
        }        

        public void FixedUpdateTankController()
        {
            if (tankRigidbody && !tankModel.b_IsDead)
            {
                if (leftJoystick.Vertical != 0)
                {
                    ForwardMovementInput();
                }
                if (leftJoystick.Horizontal != 0)
                {
                    RotationInput();
                }
            }

            if (tankView.turret && !tankModel.b_IsDead)
            {
                if (rightJoystick.Horizontal != 0)
                {
                    TurretRotationInput();
                }
            }
        }

        private void ForwardMovementInput()
        {
            Vector3 forwardInput = tankRigidbody.transform.position + leftJoystick.Vertical * tankRigidbody.transform.forward * tankModel.movementSpeed * Time.deltaTime;

            tankRigidbody.MovePosition(forwardInput);
        }

        private void RotationInput()
        {
            Quaternion desiredRotation = tankRigidbody.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * tankModel.rotationSpeed * Time.deltaTime);

            tankRigidbody.MoveRotation(desiredRotation);
        }

        private void TurretRotationInput()
        {
            Vector3 desiredRotation = Vector3.up * rightJoystick.Horizontal * tankModel.turretRotationSpeed * Time.deltaTime;

            tankView.turret.transform.Rotate(desiredRotation, Space.Self);
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

        async public void ShowHealthUI()
        {
            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(true);
                Debug.Log("Player Health enabled");
            }

            await new WaitForSeconds(3f);

            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(false);
                Debug.Log("Player Health disabled");
            }
        }

        public void SetAimUI()
        {
            tankView.aimSlider.value = tankModel.currentLaunchForce;
        }

        public void Death()
        {
            UnsubscribeEvents();

            tankModel.b_IsDead = true;

            tankView.explosionParticles.transform.position = tankView.transform.position;
            tankView.explosionParticles.gameObject.SetActive(true);

            tankView.explosionParticles.Play();
            tankView.explosionSound.Play();

            TankService.Instance.DestroyTank(this);
            tankView.Death();

            VisualEffectService.Instance.DestroyAllGameObjects();
        }

        // Called when fire button is pressed.
        private void FireButtonPressed()
        {
            tankModel.bulletIsFired = false;

            tankModel.currentLaunchForce = tankModel.minBulletLaunchForce;

            tankView.shootingAudio.clip = tankView.chargingClip;
            tankView.shootingAudio.Play();

            b_IsFireButtonPressed = true;
        }

        private void FireButtonReleased()
        {
            b_IsFireButtonPressed = false;

            if (!tankModel.bulletIsFired)
            {
                FireBullet();
            }
        }

        private void FireBulletInputCheck()
        {
            tankView.aimSlider.value = tankModel.minBulletLaunchForce;

            if (tankModel.currentLaunchForce >= tankModel.maxBulletLaunchForce && !tankModel.bulletIsFired)
            {
                tankModel.currentLaunchForce = tankModel.maxBulletLaunchForce;
                FireBullet();
            }
            else if (b_IsFireButtonPressed && !tankModel.bulletIsFired)
            {
                tankModel.currentLaunchForce += tankModel.chargeSpeed * Time.deltaTime;
                tankView.aimSlider.value = tankModel.currentLaunchForce;
            }
        }

        private void FireBullet()
        {
            tankModel.bulletIsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();

            tankModel.currentLaunchForce = tankModel.minBulletLaunchForce;
            EventService.Instance.InvokeOnPlayerFiredBulletEvent();
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
    }
}
