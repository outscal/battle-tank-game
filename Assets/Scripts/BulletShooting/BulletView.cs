using UnityEngine;

namespace BattleTank.BulletShooting
{
    public class BulletView : MonoBehaviour    //this is not the complete code,this code is just for showchasing buttel mechanishm, I will be remodel this into MVC and SO using object pool as i increase in chapters.
    {
        public GameObject Bullet;

        public float ShootForce;
        public float TimeBetweenShooting, TimeBetweenShots;
        public bool Shooting, ReadyToShoot;

        public Camera fpscam;
        public Transform attackPoint;

        public bool allowInvoke = true;
        public BulletController BulletController { get; private set; }

        public void SetBulletController(BulletController bulletController)
        {
            BulletController = bulletController;
        }

        private void Start()
        {
            ResetShot();
        }

        private void Update()
        {
            ShootingInput();
        }

        private void ShootingInput()
        {
            Shooting = Input.GetKeyDown(KeyCode.Mouse0);

            if(ReadyToShoot && Shooting)
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            ReadyToShoot = false;

            Ray ray = fpscam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            Vector3 targetPoint;
            if(Physics.Raycast(ray, out hit))
                targetPoint = hit.point;
            else
                targetPoint = ray.GetPoint(75);

            Vector3 direction = targetPoint - attackPoint.position;

            GameObject currentBullet = Instantiate(Bullet, attackPoint.position, Quaternion.identity);

            currentBullet.transform.forward = direction.normalized;

            currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * ShootForce, ForceMode.Impulse);
        
            if(allowInvoke)
            {
                Invoke("ResetShot", TimeBetweenShooting);
                allowInvoke = false;
            }
        }

        private void ResetShot()
        {
            ReadyToShoot = true;
            allowInvoke = true;
        }

    }
}