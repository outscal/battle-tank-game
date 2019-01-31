using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using Inputs;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        private float lastTime;

        public PlayerController(InputComponentScriptable inputComponentScriptable)
        {
            GameObject prefab = Resources.Load<GameObject>("Tank");
            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);

            playerModel = new PlayerModel();
            playerInput = new InputComponent();
            playerInput.SetController(this);
            playerInput.SetInputComponentValues(inputComponentScriptable);
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this, playerModel.Health);
            InputManager.Instance.AddInputComponent(playerInput);
        }

        public void MovePlayer(float hVal, float vVal)
        {
            if (playerView != null)
                playerView.MoveTank(hVal, vVal, playerModel.Speed, playerModel.RotationSpeed);
        }

        public void SpawnBullet()
        {
            if (Mathf.Abs(lastTime - Time.time) >= playerModel.FireRate)
            {
                lastTime = Time.time;
                BulletController bulletController = BulletManager.Instance.SpawnBullet();
                playerView.Shoot(bulletController);
            }
        }

        public void DestroyPlayer()
        {
            playerModel = null;
        }

        public void DamagePlayer()
        {

        }
    }
}