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

        public CharacterFireState(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        public override void OnStateEnter()
        {
            Debug.Log("[CharacterFireState] FireState: OnStart");
        }

        public override void OnStateExit()
        {
            Debug.Log("[CharacterFireState] FireState: OnExit");
        }

        public override void OnUpdate()
        {
            //playerController.SpawnBullet();
            SpawnBullet();
        }

        void SpawnBullet()
        {
            if (Mathf.Abs(lastFireTime - Time.time) >= playerController.playerModel.FireRate)
            {
                lastFireTime = Time.time;
                BulletController bulletController = BulletManager.Instance.SpawnBullet();
                playerController.playerView.Shoot(bulletController);
            }
        }

    }
}