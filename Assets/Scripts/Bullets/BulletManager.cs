using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Bullet.BulletTypes;
using Interfaces;
using System;
using Audio;
using ObjectPooling;
using Player;

public enum BulletType { slow, medium, fast }

namespace Bullet
{
    public class BulletManager : IBullet
    {
        //[SerializeField]
        //private BulletType bulletType = BulletType.medium;

        public event Action<AudioName> BulletSpawnEvent;
        private GameObject bulletPoolHolder;

        private IGameManager gameManager;

        private ObjectPool<BulletController> objectPool;

        public BulletManager()
        {
            //bulletType = BulletType.fast;

            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            objectPool = new ObjectPool<BulletController>();
            gameManager.GameOver += ResetAllBullets;

        }

        public BulletController bulletController { get; private set; }

        public BulletController SpawnBullet(BulletType bulletType)
        {
            //bulletController = (BulletController)objectPool.GetObjFromPool();
            if (bulletPoolHolder == null)
            {
                bulletPoolHolder = new GameObject();
                bulletPoolHolder.name = "BulletPoolHolder";
                GameObject.DontDestroyOnLoad(bulletPoolHolder);
            }


            if (bulletType == BulletType.fast)
                bulletController = objectPool.GetFromPool<FastBulletController>();
            else if (bulletType == BulletType.medium)
                bulletController = objectPool.GetFromPool<MediumBulletController>();
            else if (bulletType == BulletType.slow)
                bulletController = objectPool.GetFromPool<SlowBulletController>();

            BulletSpawnEvent?.Invoke(AudioName.Fire);
            //bulletController.bulletView.gameObject.SetActive(true);
            bulletController.bulletView.transform.SetParent(bulletPoolHolder.transform);
            return bulletController;
        }

        void ResetAllBullets()
        {
            foreach (var bullet in GameObject.FindObjectsOfType<BulletView>())
            {
                if(bullet.gameObject.activeInHierarchy == true)
                {
                    bullet.gameObject.SetActive(false);
                    ResetBullet(bullet.bulletController);
                }
            }

        }

        public void ResetBullet(BulletController _bulletController)
        {
            //_bulletController = null;
            objectPool.ReturnObjToPool(_bulletController);
        }

        public void OnUpdate()
        {

        }
    }
}