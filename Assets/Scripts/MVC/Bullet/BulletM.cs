using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletM 
{
    BulletC bulletController;
    public BulletM(BulletSo _bullet)
    {
        roundsPerMinute = _bullet.roundsPerMinute;
        damage = _bullet.damage;
        range = _bullet.range;
    }
    public void SetBulletController(BulletC _bulletController)
    {
        bulletController = _bulletController;
    }
    public int damage { get; }
    public int range { get; }
    public int roundsPerMinute { get; }
}
