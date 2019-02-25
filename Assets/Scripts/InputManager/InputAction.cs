using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace InputControls
{
    public abstract class InputAction
    {
        public abstract void Execute(PlayerController playerController);
    }
}
