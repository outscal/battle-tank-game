using UnityEngine;

namespace Effects
{
    [RequireComponent(typeof(ParticleSystem))]
    public class EffectController : MonoBehaviour
    {
        ParticleSystem particleEffect;
        public void playEffect(Vector3 pos)
        {
            transform.position = pos;
            GetComponent<ParticleSystem>().Play();
        }
    }
}