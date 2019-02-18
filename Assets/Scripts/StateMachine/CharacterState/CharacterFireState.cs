using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Bullet;

namespace StateMachine
{
    public class CharacterFireState : CharacterState
    {
        private PlayerController playerController;

        private float lastFireTime;
        private int lastFrame;

        public CharacterFireState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void OnStateEnter()
        {
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
                BulletController bulletController = BulletManager.Instance.SpawnBullet();
                playerController.playerView.Shoot(bulletController);

                lastFrame = Time.frameCount;
            }
        }

    }
}