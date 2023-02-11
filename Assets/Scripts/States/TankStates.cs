using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Tanks.Tank
{
    [RequireComponent(typeof(TankView))]
   public class TankStates : MonoBehaviour
    {
        public virtual void OnEnterState(){}
        public virtual void OnExitState(){}
        public virtual void Tick(){}
    } 
}


