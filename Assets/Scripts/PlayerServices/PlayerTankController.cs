using UnityEngine;
using BulletServices;
using GameplayServices;
using VFXServices;
using GlobalServices;
using UIServices;
using AchievementServices;

namespace PlayerTankServices
{
    // Handles all behaviour of player tank. // Brain of player tank.
    public class PlayerTankController 
    {
        public PlayerTankModel tankModel { get; }
        public PlayerTankView tankView { get; }

        private Rigidbody tankRigidbody; // player tank rigidbody reference.
        private Joystick rightJoystick; // Joystick references.
        private Joystick leftJoystick;

        private bool b_IsFireButtonPressed = false;

        public PlayerTankController(PlayerTankModel tankModel, PlayerTankView tankPrefab)
        {
            this.tankModel = tankModel;

            // Spawns player tank.
            tankView = GameObject.Instantiate<PlayerTankView>(tankPrefab, SpawnPointService.Instance.GetPlayerSpawnPoint());

            tankRigidbody = tankView.GetComponent<Rigidbody>();
            tankView.SetTankControllerReference(this);

            SubscribeEvent();
        }

        // To get inputs from joystick.
        public void SetJoystickReference(Joystick rightRef, Joystick leftRef)
        {
            rightJoystick = rightRef;
            leftJoystick = leftRef;
        }

        private void SubscribeEvent()
        {
            EventService.Instance.OnEnemyDeath += UpdateEnemiesKilledCount;
            EventService.Instance.OnWaveSurvived += UpdateWaveSurvivedCount;
            EventService.Instance.OnplayerFiredBullet += UpdateBulletsFiredCount;
            EventService.Instance.OnFireButtonPressed += FireButtonPressed;
            EventService.Instance.OnFireButtonReleased += FireButtonReleased;
        }

        private void UnsubscribeEvents()
        {
            EventService.Instance.OnEnemyDeath -= UpdateEnemiesKilledCount;
            EventService.Instance.OnWaveSurvived -= UpdateWaveSurvivedCount;
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

        private void UpdateWaveSurvivedCount()
        {
            tankModel.waveSurvived += 1;
            PlayerPrefs.SetInt("WaveSurvived", tankModel.waveSurvived);
            AchievementHandler.Instance.CheckForWavesSurvivedAvhievement();
        }

        private void UpdateBulletsFiredCount()
        {
            tankModel.bulletsFired += 1;
            PlayerPrefs.SetInt("BulletsFired", tankModel.bulletsFired);
            AchievementHandler.Instance.CheckForBulletFiredAchievement();
        }

        // This method is called on every frame. // To get player inputs.
        public void UpdateTankController()
        {
            // If player is alive.
            if(!tankModel.b_IsDead)
            {
                FireBulletInputCheck(); // Input check for bullet fire.
                PlayEngineAudio(); 
            }
        }

        // This method is called on every fixed update. // To do all physics calculations.
        public void FixedUpdateTankController()
        {       
            if (tankRigidbody && !tankModel.b_IsDead)
            {
                if(leftJoystick.Vertical != 0)
                {
                    AddForwardMovementInput();
                }
                if(leftJoystick.Horizontal != 0)
                {
                    AddRotationInput();
                }
            }

            if(tankView.turret && !tankModel.b_IsDead)
            {
                if(rightJoystick.Horizontal != 0)
                {
                    AddTurretRotationInput();
                }
            }
        }

        // Moves tank in forward and backward direction based on vertical input of joystick.
        private void AddForwardMovementInput()
        {
            Vector3 forwardInput = tankRigidbody.transform.position + leftJoystick.Vertical * tankRigidbody.transform.forward * tankModel.speed * Time.deltaTime;

            tankRigidbody.MovePosition(forwardInput); 
        }

        // Rotates tank based on horizontal input of joystick.
        private void AddRotationInput()
        {
            Quaternion desiredRotation = tankRigidbody.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * tankModel.rotationRate * Time.deltaTime);

            tankRigidbody.MoveRotation(desiredRotation);
        }

        // Rotates tank turret based on horizontal input of right joystick.
        private void AddTurretRotationInput()
        {
            Vector3 desiredRotation = Vector3.up * rightJoystick.Horizontal * tankModel.turretRotationRate * Time.deltaTime;

            tankView.turret.transform.Rotate(desiredRotation, Space.Self);
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
            if(tankView)
            {
                tankView.healthSlider.gameObject.SetActive(true);
            }

            await new WaitForSeconds(3f);

            if (tankView)
            {
                tankView.healthSlider.gameObject.SetActive(false);
            }
        }

        // Updates aim arrow size.
        public void SetAimUI()
        {
            tankView.aimSlider.value = tankModel.currentLaunchForce;
        }

        public void Death()
        {
            UnsubscribeEvents();

            tankModel.b_IsDead = true;

            // Move the instantiated explosion prefab to the tank's position and turn it on.
            tankView.explosionParticles.transform.position = tankView.transform.position;
            tankView.explosionParticles.gameObject.SetActive(true);

            tankView.explosionParticles.Play();
            tankView.explosionSound.Play();

            PlayerTankService.Instance.DestroyTank(this);
            tankView.Death();

            // Destroys all gameobjects after player death.
            VFXHandler.Instance.DestroyAllGameObjects();
        }

        // Called when fire button is pressed.
        private void FireButtonPressed()
        {
            tankModel.b_IsFired = false;

            // Launch force is set to minimum at the start of button press.
            tankModel.currentLaunchForce = tankModel.minLaunchForce;

            // Change the clip to the charging clip and start it playing.
            tankView.shootingAudio.clip = tankView.chargingClip;
            tankView.shootingAudio.Play();

            b_IsFireButtonPressed = true;
        }

        // Called when fire button is released.
        private void FireButtonReleased()
        {
            b_IsFireButtonPressed = false;

            // Fire bullet if not already fired.
            if(!tankModel.b_IsFired)
            {
                FireBullet();
            }
        }

        private void FireBulletInputCheck()
        {
            // To track current state of fire button.
            tankView.aimSlider.value = tankModel.minLaunchForce;

            // If the max force has been exceeded and the bullet hasn't fired yet.
            if (tankModel.currentLaunchForce >= tankModel.maxLaunchForce && !tankModel.b_IsFired)
            {
                tankModel.currentLaunchForce = tankModel.maxLaunchForce;
                FireBullet();
            }

            // Otherwise, if the fire button has just started being pressed. // Holding the fire button, not yet fired.
            else if (b_IsFireButtonPressed && !tankModel.b_IsFired)
            {              
                tankModel.currentLaunchForce += tankModel.chargeSpeed * Time.deltaTime;
                tankView.aimSlider.value = tankModel.currentLaunchForce;
            }
        }

        // To fire bullet.
        private void FireBullet()
        {
            tankModel.b_IsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            // Change the clip to the firing clip and play it.
            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();

            // Reset the launch force.
            tankModel.currentLaunchForce = tankModel.minLaunchForce;

            EventService.Instance.InvokeOnPlayerFiredBulletEvent();
        }


        private void PlayEngineAudio()
        {
            // If the tank is moving, play movement audio clip.
            if (leftJoystick.Vertical != 0 || leftJoystick.Horizontal != 0)
            {
                // If the idling clip is currently playing.
                if (tankView && tankView.movementAudio.clip == tankView.engineIdling)
                {
                    tankView.movementAudio.clip = tankView.engineDriving;
                    tankView.movementAudio.Play();
                }
            }

            // If there is no input (the tank is stationary).
            else
            {
                // If the audio source is currently playing the driving clip.
                if (tankView && tankView.movementAudio.clip == tankView.engineDriving)
                {
                    tankView.movementAudio.clip = tankView.engineIdling;
                    tankView.movementAudio.Play();
                }            
            }
        }
    }
}
