using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Bullet
{
    public class BulletController
    {
        public BulletModel bulletModel { get; protected set; }
        public BulletView bulletView { get; protected set; }

        private BulletType bulletType = BulletType.medium;

        public GameObject bulletRef { get; private set; }

        private PlayerController playerController;

        public BulletController()
        {
            bulletModel = getBulletModel();
            GameObject prefab = Resources.Load<GameObject>(BulletName());
            bulletRef = GameObject.Instantiate<GameObject>(prefab);
            bulletView = getBulletView();
            bulletView.bulletController = this;
        }

        public void SpawnBullet(Vector3 direction, Vector3 spawnPos, Vector3 rotation, PlayerController playerController)
        {
            this.playerController = playerController;
            bulletView.transform.position = spawnPos;
            bulletView.transform.rotation = Quaternion.Euler(rotation);
            bulletView.MoveBullet(direction, bulletModel.Force, bulletModel.DestroyTime);
        }

        public void DestroyController()
        {
            bulletModel = null;
            BulletManager.Instance.RemoveController(this);
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