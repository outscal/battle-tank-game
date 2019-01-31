using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bullet;

namespace Player
{
    public class PlayerController
    {
        public PlayerModel playerModel { get; private set; }
        public PlayerView playerView { get; private set; }

        public PlayerController()
        {
            GameObject prefab = Resources.Load<GameObject>("Tank");
            GameObject tankObj = GameObject.Instantiate<GameObject>(prefab);

            playerModel = new PlayerModel();
            playerView = tankObj.GetComponent<PlayerView>();
            playerView.SetController(this);
        }

        public void MovePlayer(float hVal, float vVal)
        {
            if (playerView != null)
                playerView.MoveTank(hVal, vVal, playerModel.Speed, playerModel.RotationSpeed);
        }

        public void SpawnBullet()
        {
            BulletController bulletController = BulletManager.Instance.SpawnBullet();

            playerView.Shoot(bulletController);
        }

        public void DestroyPlayer()
        {
            playerModel = null;
        }

    }
}