using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EffectController : MonoBehaviour
    {
        public void playEffect(Vector3 pos)
        {
            transform.position = pos;
            GetComponent<ParticleSystem>().Play();
        }
    }
}