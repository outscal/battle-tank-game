using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using System;
using Audio;

namespace Interfaces
{
    public interface IBullet : IService
    {
        event Action<AudioName> BulletSpawnEvent;

        BulletController SpawnBullet();
        void DestroyBullet(BulletController bulletController);
    }
}