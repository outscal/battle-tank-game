using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Interfaces
{
    public interface IInput : IService
    {
        void AddInputComponent(InputComponent inputComponent);

        void RemoveInputComponent(InputComponent inputComponent);

    }
}