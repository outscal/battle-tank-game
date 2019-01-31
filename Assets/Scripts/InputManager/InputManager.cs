using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Player;
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

                if (inputComponent.horizontalVal != 0 || inputComponent.verticalVal != 0)
                    Move(inputComponent.horizontalVal, inputComponent.verticalVal, inputComponent.GetController());

                if (inputComponent.shoot == true)
                {
                    Shoot(inputComponent.GetController());
                }
            }

        }

        void Move(float horizontal, float vertical, PlayerController playerController)
        {
            playerController.MovePlayer(horizontal, vertical);
        }

        void Shoot(PlayerController playerController)
        {
            playerController.SpawnBullet();
        }

        public  void AddInputComponent(InputComponent inputComponent)
        {
            inputComponentList.Add(inputComponent);
        }

    }
}