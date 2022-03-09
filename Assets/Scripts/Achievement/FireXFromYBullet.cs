using Bullet;
using UnityEngine;

namespace Achievement
{
    [System.Serializable]
    public class FireXFromYBullet:Achievement
    {
        #region Serialized Data Members

        [SerializeField] private int neededNumber = 10;
        [SerializeField] private Scriptable_Object.Bullet.Bullet bullet;

        #endregion

        #region Private Data members

        private int _counter;

        #endregion

        #region Constructors
        
        #endregion

        #region Private Functions

        private void CheckTheFiredBullet(Scriptable_Object.Bullet.Bullet theBullet)
        {
            if(bullet == theBullet) UpdateAchievement();
        }

        #endregion
        protected override void UpdateAchievement()
        {
            _counter++;
            if (_counter == neededNumber)
            {
                InvokeAchievement(this);
                Unsubscribe();
            }
        }

        public override void Subscribe()
        {
            BulletService.BulletFired += CheckTheFiredBullet;
        }

        public override void Unsubscribe()
        {
            BulletService.BulletFired -= CheckTheFiredBullet;
        }

        public override string Text()
        {
            return "Fire " + neededNumber.ToString("00") + " of " + bullet.name;
        }

        public override void Reset()
        {
            _counter = 0;
        }
    }
}