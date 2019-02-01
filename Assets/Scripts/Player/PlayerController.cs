using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bullet;
using Inputs;
using UI;

public class PlayerData
{
    public int score, health;
}

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }
        public InputComponent playerInput { get; private set; }

        private PlayerData playerData = new PlayerData();

        public PlayerData PlayerData
        {
            get { return playerData; }
        }

        private float lastFireTime;

        public PlayerController(InputComponentScriptable inputComponentScriptable)
        {
            GameObject prefab = Resources.Load<GameObject>("Tank");
            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);

            playerModel = new PlayerModel();
            playerInput = new InputComponent();
            playerInput.playerController = this;
            playerInput.inputComponentScriptable = inputComponentScriptable;
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);
            InputManager.Instance.AddInputComponent(playerInput);
            GameUI.Instance.SetPlayerHealth(playerModel.Health);
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
            playerModel = null;
        }

        public void TakeDamage(int value)
        {
            playerModel.Health -= value;
            GameUI.Instance.UpdatePlayerHealth(value);
            setPlayerHealth(playerModel.Health);

            if (playerModel.Health <= 0)
                playerView.PlayerDie();
        }

        public void setPlayerScore(int value)
        {
            playerData.score = value;
            Debug.Log("[PlayerController]: Score " + value);
        }

        void setPlayerHealth(int value)
        {
            playerData.health = value;
            Debug.Log("[PlayerController]: Health " + value);
        }
    }
}