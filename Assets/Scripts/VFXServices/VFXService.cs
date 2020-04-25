using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
namespace VFXServices
{

    public class VFXService : GenericSingleton<VFXService>
    {
        public GameObject tankExplosion;
        public GameObject bulletExplosion;

        public void TankExplosionEffects(Vector3 position)
        {
            GameObject gameObject = Instantiate(tankExplosion, position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }

        public void BulletEffects(Vector3 position)
        {
            GameObject gameObject = Instantiate(bulletExplosion, position, Quaternion.identity);
            Destroy(gameObject, 1f);
        }
    }
}
