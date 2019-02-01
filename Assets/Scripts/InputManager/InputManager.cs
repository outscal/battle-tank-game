using System.Collections.Generic;
using Common;

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

    }
}