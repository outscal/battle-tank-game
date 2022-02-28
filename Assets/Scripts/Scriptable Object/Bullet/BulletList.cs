using UnityEngine;

namespace Scriptable_Object.Bullet
{
    [CreateAssetMenu(fileName = "NewBulletList", menuName = "User/Bullet/BulletList", order = 0)]
    public class BulletList : ScriptableObject
    {
        [SerializeField] private Bullet[] bullets;

        public Bullet[] List => bullets;
    }
}