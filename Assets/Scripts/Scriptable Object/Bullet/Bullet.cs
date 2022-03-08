using Bullet;
using UnityEngine;

namespace Scriptable_Object.Bullet
{
    [CreateAssetMenu(fileName = "NewBullet", menuName = "User/Bullet/Bullet", order = 1)]
    public class Bullet : ScriptableObject
    {
        #region Serialized Data members

        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletModel bulletModel;

        #endregion

        #region Getters

        public BulletView BulletView => bulletView;
        public BulletModel BulletModel => bulletModel;

        #endregion
    }
}