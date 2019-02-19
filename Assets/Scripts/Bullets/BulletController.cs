using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Interfaces;

namespace Bullet
{
    public class BulletController
    {
        public BulletModel bulletModel { get; protected set; }
        public BulletView bulletView { get; protected set; }

        private BulletType bulletType = BulletType.medium;

        public GameObject bulletRef { get; private set; }

        private PlayerController playerController;
        private IBullet bulletManager;

        public BulletController()
        {
            if (bulletManager == null)
                bulletManager = StartService.Instance.GetService<IBullet>();

            bulletModel = getBulletModel();
            GameObject prefab = Resources.Load<GameObject>(BulletName());
            bulletRef = GameObject.Instantiate<GameObject>(prefab);
            bulletView = getBulletView();
            bulletView.bulletController = this;
        }

        public void SpawnBullet(Vector3 direction, Vector3 spawnPos, Vector3 rotation, PlayerController playerController)
        {
            this.playerController = playerController;
            bulletView.shooterID = playerController.playerID;
            bulletView.transform.position = spawnPos;
            bulletView.transform.rotation = Quaternion.Euler(rotation);
            bulletView.MoveBullet(direction, bulletModel.Force, bulletModel.DestroyTime);
        }

        public void DestroyController()
        {
            bulletModel = null;
            bulletManager.DestroyBullet(this);
        }

        protected virtual BulletModel getBulletModel()
        {
            return new BulletModel();
        }

        protected virtual string BulletName()
        {
            string name = "SlowBullet";
            return name;
        }

        protected virtual BulletView getBulletView()
        {
            return bulletRef.GetComponent<BulletView>();
        }

    }
}