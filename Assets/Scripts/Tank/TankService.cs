using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Tank
{
    public interface ITankService
    {
        
        public TankController CreateTank(Scriptable_Object.Tank.Tank tank);

        public void Destroy(TankController controller);

        public IEnumerator KillTank(TankController controller, ParticleSystem explosion)
        {
            GameObject.Destroy(controller.TankView.gameObject);
            yield return Explode(controller, explosion);
            controller = null;
        }

        public IEnumerator Explode(TankController controller, ParticleSystem explosion)
        {
            ParticleSystem _explosion = GameObject.Instantiate(explosion, controller.TankView.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(1.05f);
            GameObject.Destroy(_explosion.gameObject);
        }

        
    }
}
