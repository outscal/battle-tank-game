using UnityEngine;
using BulletServices;

namespace PlayerTankServices
{
    public class PlayerTankController 
    {
        public PlayerTankModel tankModel { get; }
        public PlayerTankView tankView { get; }

        private Rigidbody tankRigidbody;
        private Joystick rightJoystick;
        private Joystick leftJoystick;
        private Camera camera;

        public PlayerTankController(PlayerTankModel tankModel, PlayerTankView tankPrefab)
        {
            this.tankModel = tankModel;
            tankView = GameObject.Instantiate<PlayerTankView>(tankPrefab);
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
            camera = cameraRef;
            camera.transform.SetParent(tankView.turret.transform);
        }

        public void UpdateTankController()
        {
            FireBulletInputCheck();
        }

        public void FixedUpdateTankController()
        {
            if(tankRigidbody)
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

            if(tankView.turret)
            {
                if(rightJoystick.Horizontal != 0)
                {
                    AddTurretRotationInput();
                }
            }
        }

        private void AddForwardMovementInput()
        {
            Vector3 forwardInput = tankRigidbody.transform.position + leftJoystick.Vertical * tankRigidbody.transform.forward * tankModel.speed * Time.deltaTime;

            tankRigidbody.MovePosition(forwardInput);
        }

        private void AddRotationInput()
        {
            Quaternion desiredRotation = tankRigidbody.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * tankModel.rotationRate * Time.deltaTime);

            tankRigidbody.MoveRotation(desiredRotation);
        }

        private void AddTurretRotationInput()
        {
            Vector3 desiredRotation = Vector3.up * rightJoystick.Horizontal * tankModel.turretRotationRate * Time.deltaTime;

            tankView.turret.transform.Rotate(desiredRotation, Space.Self);
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

            camera.transform.parent = null;
            tankView.Death();
        }

        private void FireBulletInputCheck()
        {
            // To track current state of fire button.
            tankView.aimSlider.value = tankModel.minLaunchForce;

            if (tankModel.currentLaunchForce >= tankModel.maxLaunchForce && !tankModel.b_IsFired)
            {
                // At max charge, not yet fired.
                tankModel.currentLaunchForce = tankModel.maxLaunchForce;
                FireBullet();
            }

            else if (Input.GetButtonDown("Jump"))
            {
                // Pressed fire button for the first time.
                tankModel.b_IsFired = false;
                tankModel.currentLaunchForce = tankModel.minLaunchForce;

                tankView.shootingAudio.clip = tankView.chargingClip;
                tankView.shootingAudio.Play();
            }

            else if (Input.GetButton("Jump") && !tankModel.b_IsFired)
            {
                // Holding the fire button, not yet fired.
                tankModel.currentLaunchForce += tankModel.chargeSpeed * Time.deltaTime;
                tankView.aimSlider.value = tankModel.currentLaunchForce;
            }

            else if (Input.GetButtonUp("Jump") && !tankModel.b_IsFired)
            {
                FireBullet();
            }
        }

        private void FireBullet()
        {
            tankModel.b_IsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();

            tankModel.currentLaunchForce = tankModel.minLaunchForce;
        }
    }
}
