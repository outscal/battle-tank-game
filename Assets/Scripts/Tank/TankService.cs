using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Tank
{
    public interface ITankService
    {
        
        public TankController CreateTank(Scriptable_Object.Tank.Tank tank);

        public void Destroy(TankController controller);

        public IEnumerator KillTank(TankController controller, ParticleSystem explosion)
        {
            GameObject.Destroy(controller.TankView.gameObject);
            ParticleSystem _explosion = GameObject.Instantiate(explosion, controller.TankView.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.05f);
            GameObject.Destroy(_explosion.gameObject);
            controller = null;
        }
    }
}
