using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outscal.BattleTank
{
    /// <summary>
    /// this class instantiates the tank model in game
    /// </summary>
    public class TankController
    {
        private Rigidbody rigidbody;
        // private Vector3 movement;

        private float canFire;
        private float fireRate = 5f;
        private object firepoint;

        public TankModel TankModel { get; private set; }
        public TankView TankView { get; private set; }

        public TankController(TankModel tankModel, TankView tankPrefab)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            rigidbody = TankView.GetComponent<Rigidbody>();
            TankView.SetTankController(this);
            TankModel.SetTankController(this);
 
            Debug.Log("tank prefab instantiated");
        }

        //tank movement
        public void TankMovement(float movement)
        {
            Vector3 mov = TankView.transform.position;
            mov += movement * TankModel.Speed * Time.deltaTime * TankView.transform.forward;
            rigidbody.MovePosition(mov);

        }

        //tank rotation
        public void TankRotation(float rotation)
        {
            Vector3 vector = new Vector3(0f, rotation * TankModel.rotationSpeed, 0f);
            //Vector3 vector = new Vector3(0f, rotation * 10, 0f);
            Quaternion angle = Quaternion.Euler(vector * Time.fixedDeltaTime);
            rigidbody.MoveRotation(angle * rigidbody.rotation);
        }
        
        //tank shooting
        public void ShootBullet()
        {
            //EventService.instance.InvokeOnPlayerFiredBulletEvent();
            BulletService.GetInstance().CreateNewBullet(GetFiringPosition(), GetFiringAngle(), GetBullet());
        }

        //private void UpdateBulletsFiredCounter()
        //{
            //ankModel.BulletsFired += 1;
            //PlayerPrefs.SetInt("BulletsFired", TankModel.BulletsFired);
           // AchievementService.instance.GetAchievementController().CheckForBulletFiredAchievement();
        //}

        //returning bullet firing position
        public Vector3 GetFiringPosition()
        {
            return TankView.BulletShootPoint.position;
        }

        //returning firing angle
        public Quaternion GetFiringAngle()
        {
            return TankView.transform.rotation;
        }

        //returning bullet scriptable object
        public BulletScriptableObject GetBullet()
        {
            return TankModel.bulletType;
        }

        //returning current position of tank
        public Vector3 GetCurrentTankPosition()
        {
            return TankView.transform.position;
        }


        //void Shoot()
        //{
        //    if (Input.GetButtonDown("Fire1") && canFire < Time.time)
        //    {
        //        //StartCoroutine(PlayShootEffect());
        //        // m_ExplosionParticles.Play();
        //        // Debug.Log(canFire);
        //        canFire = fireRate + Time.time;
        //        GameObject bullet = BulletController.BulletType.Fast);
        //        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //        rb.AddForce(firepoint.forward * bulletForce, ForceMode.Impulse);
        //    }
        //}
    }
}