using TankBattle.Extensions;
using TankBattle.Tank.Bullets;
using UnityEngine;

namespace TankBattle.Tank
{
    public class TankController
    {
        public TankModel GetTankModel { get; }
        public TankView GetTankView { get; }

        private Rigidbody rb;
        private bool isDead;

        private float currentLaunchForce;
        public float CurrentLaunchForce { get => currentLaunchForce; set => currentLaunchForce = value; }

        public float ChargeSpeed { get; }
        public bool IsFired { get; set; }

        public TankController(TankModel tankModel, TankView tankPrefab, Vector3 spawnPosition)
        {
            GetTankModel = tankModel;
            GetTankView = Object.Instantiate(tankPrefab, spawnPosition, Quaternion.identity);
            GetTankView.SetColorOnAllRenderers(GetTankModel.GetColor);
            isDead = false;

            ChargeSpeed = (GetTankModel.maxLaunchForce - GetTankModel.minLaunchForce) / GetTankModel.maxChargeTime;

            // either assign tankView references here or inside the 
            // TankBattle.Tank.CreateTank.CreateTankService.Instance.CreateTank method
            // after calling this ctor
            //GetTankView.SetTankController(this);
            //GetTankView.SetMaxHealth(GetTankModel.GetSetHealth);
            //GetTankView.SetHealthUI();

            // using this to assign controller ref results in slightly weird/slower/non-uniform movement in game
        }

        //Movement-related logic
        //and jump if needed
        public void MoveRotate(Vector2 _moveDirection)
        {
            Vector3 directionVector = _moveDirection.switchYAndZValues();
            Move(directionVector);
            Rotate(directionVector);
        }
        private void Move(Vector3 moveDirection)
        {
            if (!rb)
            {
                rb = GetTankView.getRigidbody();
            }

            rb.MovePosition(rb.position + moveDirection * GetTankModel.Speed * Time.deltaTime);
        }
        private void Rotate(Vector3 rotateDirection)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotateDirection, Vector3.up);
            targetRotation = Quaternion.RotateTowards
            (
                GetTankView.transform.localRotation,
                targetRotation,
                GetTankModel.RotateSpeed * Time.fixedDeltaTime
            );

            rb.MoveRotation(targetRotation);
        }
        public void Jump()
        {
            if (!rb)
            {
                rb = GetTankView.GetComponent<Rigidbody>();
            }
            rb.AddForce(Vector3.up * GetTankModel.JumpForce * Time.deltaTime, ForceMode.Impulse);
        }

        // health related logic
        public void TakeDamage(float amount)
        {
            GetTankModel.GetSetHealth -= amount;
            GetTankView.SetHealthUI();
            if (GetTankModel.GetSetHealth <= 0f && !isDead)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            isDead = true;
            GetTankView.InstantiateOnDeath();
        }

        // Shooting Related

        public void Fire()
        {
            IsFired = true;
            Transform fireTransform = GetTankView.GetFireTransform();
            ShellController bullet = CreateShellService.Instance.CreateBulletShell(fireTransform);

            bullet.GetShellView.AddVelocity(currentLaunchForce * fireTransform.forward);
            GetTankView.PlayFiredSound();
            currentLaunchForce = GetTankModel.minLaunchForce;
        }
    }
}