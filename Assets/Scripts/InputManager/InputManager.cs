using System.Collections.Generic;
using Common;
using UnityEngine;

namespace Inputs
{
    public class InputManager : Singleton<InputManager>
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        // Update is called once per frame
        void Update()
        {
            foreach (InputComponent inputComponent in inputComponentList)
            {
                inputComponent.OnUpdate();
            }
        }

        public  void AddInputComponent(InputComponent inputComponent)
        {
            inputComponentList.Add(inputComponent);
        }

        public void RemoveInputComponent(InputComponent inputComponent)
        {
            for (int i = 0; i < inputComponentList.Count; i++)
            {
                if (inputComponentList[i] == inputComponent)
                {
                    inputComponentList.RemoveAt(i);
                    Debug.Log("[InputManager] Remove InputComponent at index " + i);
                }
            }
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }

    }
}