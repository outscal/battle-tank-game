using Generic;
using System.Collections.Generic;
using UnityEngine;

namespace Singalton
{
    public class VFXManager : MonoSingletonGeneric<VFXManager>
    {
        public List<VFX> VFXClip = new List<VFX>();

        protected override void Awake()
        {
            base.Awake();
        }


        public void PlayVFXClip(VFXName vfxName, Vector3 VFXPosition, Transform parent)
        {
            for (int i = 0; i < VFXClip.Count; i++)
            {
                if (VFXClip[i].Name == vfxName)
                {
                    ParticleSystem vfx = Instantiate(VFXClip[i].vfx, parent) as ParticleSystem;
                    vfx.transform.position = VFXPosition;
                    vfx.gameObject.SetActive(true);
                    vfx.Play();
                    ParticleSystem.MainModule mainModule = vfx.main;
                    Destroy(vfx.gameObject, mainModule.duration);
                }
            }
        }

    }
}
