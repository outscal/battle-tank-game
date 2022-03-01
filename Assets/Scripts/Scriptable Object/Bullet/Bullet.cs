using System;
using Bullet;
using UnityEngine;

namespace Scriptable_Object.Bullet
{
    [CreateAssetMenu(fileName = "NewBullet", menuName = "User/Bullet/Bullet", order = 1)]
    public class Bullet : ScriptableObject
    {
        [SerializeField] private TrajectoryType trajectoryType = TrajectoryType.None;
        [SerializeField] private BulletView bulletView;
        [SerializeReference] private BulletModel bulletModel;

        public TrajectoryType TrajectoryType => trajectoryType;
        public BulletView BulletView => bulletView;
        public BulletModel BulletModel => bulletModel;

        private TrajectoryType _lastType;
        private BulletModel _saved;

        public Bullet()
        {
            _lastType = trajectoryType;
        }
        private void OnValidate()
        {
            if (trajectoryType!=_lastType)
            {
                _lastType = trajectoryType;
                if (trajectoryType == TrajectoryType.None) _saved = bulletModel;
                
                bulletModel = (trajectoryType != TrajectoryType.None) ? (_saved!=null)?new BulletModel(_saved):new BulletModel() : null;
            }
        }
    }
}