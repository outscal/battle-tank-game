using UnityEngine;
using GameServices;
using BulletServices;

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
        }

        // Sets the reference to joystick on the Canvas.
        public void SetJoystickReference(Joystick _leftJoystick, Joystick _rightJoystick)
        {
            leftJoystick = _leftJoystick;
            rightJoystick = _rightJoystick;
        }

        // This method is called on every fixed update. // To do all physics calculations.
        public void UpdateTankController()
        {
                if (leftJoystick.Vertical != 0)
                {
                    ForwardMovementInput();
                }
                if (leftJoystick.Horizontal != 0)
                {
                    RotationInput();
                }

                if (tankView.turret && !tankModel.b_IsDead)
                {
                    if (rightJoystick.Horizontal != 0)
                    {
                        TurretRotationInput();
                    }
                }
        }

        // Forward and backward direction movement based on vertical input of joystick.
        private void ForwardMovementInput()
        {
            Vector3 forwardInput = tankRigidbody.transform.position + leftJoystick.Vertical * tankRigidbody.transform.forward * tankModel.movementSpeed * Time.deltaTime;

            tankRigidbody.MovePosition(forwardInput);
        }

        // Rotates tank based on horizontal input of joystick.
        private void RotationInput()
        {
            Quaternion desiredRotation = tankRigidbody.transform.rotation * Quaternion.Euler(Vector3.up * leftJoystick.Horizontal * tankModel.rotationSpeed * Time.deltaTime);

            tankRigidbody.MoveRotation(desiredRotation);
        }

        // Rotates tank turret based on horizontal input of right joystick.
        private void TurretRotationInput()
        {
            Vector3 desiredRotation = Vector3.up * rightJoystick.Horizontal * tankModel.turretRotationSpeed * Time.deltaTime;

            tankView.turret.transform.Rotate(desiredRotation, Space.Self);
        }

        // Reduce current health by the amount of damage done.
        public void TakeDamage(int damage)
        {
            tankModel.health -= damage;

            // If health goes below zero, tank dies.
            if (tankModel.health <= 0 && !tankModel.b_IsDead)
            {
                Death();
            }
        }

        public void Death()
        {
            tankModel.b_IsDead = true;

            TankService.Instance.DestroyTank(this);
            tankView.Death();
        }

        // Called when fire button is pressed.
        private void FireButtonPressed()
        {
            tankModel.bulletIsFired = false;

            // Launch force is set to minimum at the start of button press.
            tankModel.currentLaunchForce = tankModel.minBulletLaunchForce;

            b_IsFireButtonPressed = true;
        }

        // Called when fire button is released.
        private void FireButtonReleased()
        {
            b_IsFireButtonPressed = false;

            // Fire bullet if not already fired.
            if (!tankModel.bulletIsFired)
            {
                FireBullet();
            }
        }

        private void FireBulletInputCheck()
        {
            // If the max force has been exceeded and the bullet hasn't fired yet.
            if (tankModel.currentLaunchForce >= tankModel.maxBulletLaunchForce && !tankModel.bulletIsFired)
            {
                tankModel.currentLaunchForce = tankModel.maxBulletLaunchForce;
                FireBullet();
            }

            // Otherwise, if the fire button has just started being pressed. // Holding the fire button, not yet fired.
            else if (b_IsFireButtonPressed && !tankModel.bulletIsFired)
            {
                tankModel.currentLaunchForce += tankModel.chargeSpeed * Time.deltaTime;
            }
        }

        // To fire bullet.
        private void FireBullet()
        {
            tankModel.bulletIsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            // Reset the launch force.
            tankModel.currentLaunchForce = tankModel.minBulletLaunchForce;
        }

        // Calls some asynchronous methods to destroy the world gradually with a cool effect.
        public void DestroyWorld()
        {
            DestroyTanks();
            DestoryEnv();
        }

        // Destroys all Game Objects Tagged as 'Tank' one by one using async await.
        private async void DestroyTanks()
        {
            GameObject[] tanks = GameObject.FindGameObjectsWithTag("Tank");
            for (int i = 0; i < tanks.Length; i++)
            {
                GameObject.Destroy(tanks[i]);
                await new WaitForSeconds(0.1f);
            }
        }

        // Destroys all Game Objects Tagged as 'Ground' one by one using async await.
        private async void DestoryEnv()
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Ground");
            for (int i = 0; i < objects.Length; i++)
            {
                GameObject.Destroy(objects[i]);
                await new WaitForSeconds(0.3f);
            }
        }

        // To fire bullet.
        /*private void FireBullet()
        {
            tankModel.b_IsFired = true;
            BulletService.Instance.FireBullet(tankModel.bulletType, tankView.fireTransform, tankModel.currentLaunchForce);

            // Change the clip to the firing clip and play it.
            tankView.shootingAudio.clip = tankView.fireClip;
            tankView.shootingAudio.Play();

            // Reset the launch force.
            tankModel.currentLaunchForce = tankModel.minLaunchForce;
        }*/
    }
}
