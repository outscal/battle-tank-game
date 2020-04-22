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
            var go = Instantiate(tankExplosion, position, Quaternion.identity);
            Destroy(go, 1f);
        }

        public void BulletEffects(Vector3 position)
        {
            var go = Instantiate(bulletExplosion, position, Quaternion.identity);
            Destroy(go, 1f);
        }
    }
}
