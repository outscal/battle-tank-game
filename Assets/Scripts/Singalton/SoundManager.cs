using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic;


namespace Singalton
{
    public class SoundManager : MonoSingletonGeneric<SoundManager>
    {
        protected override void Awake()
        {
            base.Awake();
        }
    }
}
