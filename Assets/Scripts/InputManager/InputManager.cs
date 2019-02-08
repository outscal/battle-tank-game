using System.Collections.Generic;
using Common;
using UnityEngine;
using BTManager;

namespace Inputs
{
    public class InputManager : Singleton<InputManager>
    {
        private List<InputComponent> inputComponentList = new List<InputComponent>();

        private bool onPaused = false;

        private void Start()
        {
            GameManager.Instance.GamePaused += OnPaused;
            GameManager.Instance.GameUnpaused += OnUnPaused;
        }

        // Update is called once per frame
        void Update()
        {
            if (onPaused == false)
            {
                foreach (InputComponent inputComponent in inputComponentList)
                {
                    inputComponent.OnUpdate();
                }
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

        void OnPaused()
        {
            onPaused = true;
        }

        void OnUnPaused()
        {
            onPaused = false;
        }

        public void EmptyInputComponentList()
        {
            inputComponentList.Clear();
        }

    }
}