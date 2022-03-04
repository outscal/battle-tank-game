using System;
using Bullet;
using UnityEngine;

namespace Scriptable_Object.Bullet
{
    [CreateAssetMenu(fileName = "NewBullet", menuName = "User/Bullet/Bullet", order = 1)]
    public class Bullet : ScriptableObject
    {
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletModel bulletModel;
        
        public BulletView BulletView => bulletView;
        public BulletModel BulletModel => bulletModel;

        private TrajectoryType _lastType;
        private BulletModel _saved;
    }
}