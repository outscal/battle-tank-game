using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputControls;

namespace Interfaces
{
    public interface IInput : IService
    {
        void AddInputComponent(InputComponent inputComponent);

        void RemoveInputComponent(InputComponent inputComponent);

    }
}