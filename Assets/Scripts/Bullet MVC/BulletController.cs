using UnityEngine;

namespace BulletServices
{
    // Handles all behaviour of bullet.
    public class BulletController
    {
        public BulletModel BulletModel { get; }
        public BulletView BulletView { get; }

        // This Constructor Spawns a bullet and Fire it just after it is Spawned.
        public BulletController(BulletModel bulletModel, BulletView bulletPrefab, Transform bulletSpawner, float launchForce)
        {
            // Holds all data of bullet. 
            BulletModel = bulletModel;

            // Visual instance of bullet.
            BulletView = GameObject.Instantiate<BulletView>(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            BulletView.BulletInitialize(this);

            // Set velocity of bullet as per input launch force.
            BulletView.GetComponent<Rigidbody>().velocity = bulletSpawner.forward * launchForce;
        }
    }
}
