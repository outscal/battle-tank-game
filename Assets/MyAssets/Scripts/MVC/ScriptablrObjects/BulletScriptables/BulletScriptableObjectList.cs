using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bullet;
using Bullet.View;


namespace ScriptableObj
{
    [CreateAssetMenu(fileName = "BulletScriptableObjectList", menuName = "ScriptableObjects/NewBulletListScriptableObject")]
    public class BulletScriptableObjectList : ScriptableObject
    {
        public BulletScriptableObject[] bullet;
    }
}