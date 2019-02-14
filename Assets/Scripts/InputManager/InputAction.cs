using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public abstract class InputAction
    {
        public abstract void Execute(int shooterID);
    }
}
