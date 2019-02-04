using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using Inputs;
using UI;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        public event Action<int> scoreUpdate;
        public event Action<int> healthUpdate;

        private float lastFireTime;

        public PlayerController(InputComponentScriptable inputComponentScriptable, Vector3 position)
        {
            GameObject prefab = Resources.Load<GameObject>("Tank");
            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);
            tankObj.transform.position = position;

            playerModel = new PlayerModel();
            playerInput = new InputComponent();
            playerInput.playerController = this;
            playerInput.inputComponentScriptable = inputComponentScriptable;
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);
            InputManager.Instance.AddInputComponent(playerInput);
            PlayerManager.Instance.playerSpawned += InvokeEvents;
        }

        private void InvokeEvents()
        {
            healthUpdate?.Invoke(playerModel.Health);
            scoreUpdate?.Invoke(playerModel.score);
        }

        public void MovePlayer(float hVal, float vVal)
        {
            if (playerView != null)
                playerView.MoveTank(hVal, vVal, playerModel.Speed, playerModel.RotationSpeed);
        }

        public void SpawnBullet()
        {
            if (Mathf.Abs(lastFireTime - Time.time) >= playerModel.FireRate)
            {
                lastFireTime = Time.time;
                BulletController bulletController = BulletManager.Instance.SpawnBullet();
                playerView.Shoot(bulletController);
            }
        }

        public void DestroyPlayer()
        {
            PlayerManager.Instance.playerSpawned -= InvokeEvents;
            GameUI.InstanceClass.Respawn(playerInput);
            playerModel = null;
        }

        public void TakeDamage(int value)
        {
            playerModel.Health -= value;
            healthUpdate?.Invoke(playerModel.Health);
            setPlayerHealth(playerModel.Health);

            if (playerModel.Health <= 0)
            {
                Debug.Log("[PlayerController]: Score " + playerModel.score);
                Debug.Log("[PlayerController]: Health " + playerModel.Health);
                playerView.PlayerDie();
            }
        }

        public void setPlayerScore(int value)
        {
            playerModel.score += value;
            scoreUpdate?.Invoke(playerModel.score);
            Debug.Log("[PlayerController]: Score " + playerModel.score);
        }

        void setPlayerHealth(int value)
        {
            playerModel.Health = value;
            Debug.Log("[PlayerController]: Health " + value);
        }
    }
}