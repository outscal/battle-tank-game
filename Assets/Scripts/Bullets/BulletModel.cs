using System;

namespace Bullet
{
    public class BulletModel
    {
        private int damage = 10;

        public int Damage
        {
            get { return damage; }
            protected set { damage = value; }
        }

        private float force = 10f;

        public float Force
        {
            get { return force; }
            protected set { force = value; }
        }

        private float destroyTime = 1.5f;

        public float DestroyTime
        {
            get { return destroyTime; }
            protected set { destroyTime = value; }
        }
    }
}