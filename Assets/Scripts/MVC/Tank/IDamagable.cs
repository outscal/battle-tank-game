using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public interface IDamagable 
    {
        void TakeDamage(int damage);
        //void TakeDamage(BulletType bulletType, int damage);

    }
}