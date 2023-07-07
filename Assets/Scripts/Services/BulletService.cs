using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletService : GenericPoolService<BulletController>
{
    [SerializeField] private BulletView bulletView;
    [SerializeField] private BulletSOList bulletSOList;
    [SerializeField] private int waitTime;
    public BulletPoolService poolService;
    public Action<int> onBulletFired;

    private void Start()
    {
        poolService = GetComponent<BulletPoolService>();

    }
    public void BulletShootByTank(Transform bulletSpawnPoint)
    {
        BulletController bulletController;
        bulletController = poolService.GetBullet(bulletView);
    }

    public BulletScriptableObject BulletRandomizer()
    {
        int index = UnityEngine.Random.Range(0, bulletSOList.bulletList.Count);
        return bulletSOList.bulletList[index];
    }
}


