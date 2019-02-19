using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Bullet;
using Interfaces;

namespace StateMachine
{
    public class CharacterFireState : CharacterState
    {
        private PlayerController playerController;

        private float lastFireTime;
        private int lastFrame;

        private IBullet bulletManager;

        public CharacterFireState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void OnStateEnter()
        {
            if (bulletManager == null)
                bulletManager = StartService.Instance.GetService<IBullet>();
            //Debug.Log("[CharacterFireState] FireState: OnStart");
            //SpawnBullet();
        }

        public override void OnStateExit()
        {
            //Debug.Log("[CharacterFireState] FireState: OnExit");
        }

        public override void OnUpdate()
        {
            SpawnBullet();
        }

        void SpawnBullet()
        {
            if (Mathf.Abs(lastFireTime - Time.time) >= playerController.playerModel.FireRate)
            {
                lastFireTime = Time.time;
                BulletController bulletController = bulletManager.SpawnBullet();
                playerController.playerView.Shoot(bulletController);

                lastFrame = Time.frameCount;
            }
        }

    }
}