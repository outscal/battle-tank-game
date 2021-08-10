using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{

    [CreateAssetMenu(fileName = "BulletScriptableObjects", menuName = "ScriptableObject/NewBullet")]
    public class BulletScriptableObjects : ScriptableObject
    {
        public BulletView bulletView;
        public string bulletName;
        public float bulletForce;

        // public float maxLifeTime;// 1.5f
    }

    [CreateAssetMenu(fileName = "BulletSO_List", menuName = "ScriptableObjectList/BulletListOfSO")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObjects[] bullets;
    }



}
