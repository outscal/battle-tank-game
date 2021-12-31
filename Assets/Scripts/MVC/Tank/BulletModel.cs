using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MVC.Tank
{
    public class BulletModel 
    {
        public BulletModel(BulletScriptableObject bulletScriptableObject)
        {
            DamageDealt = bulletScriptableObject.DamageDealt;
        }

        public float DamageDealt { get; private set; }
    }
}