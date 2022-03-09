using Tank;
using UnityEngine;

namespace Achievement
{
    [System.Serializable]
    public class KillXTanks:Achievement
    {
        #region Serialized Data members

        [SerializeField] private int neededNumber = 10;

        #endregion

        #region Private Data members

        private int _counter;

        #endregion
        protected override void UpdateAchievement()
        {
            _counter++;
            if (_counter >= neededNumber)
            {
                InvokeAchievement(this);
                Unsubscribe();
            }
        }

        public override void Subscribe()
        {
            EnemyTankService.TankDied += UpdateAchievement;
        }

        public override void Unsubscribe()
        {
            EnemyTankService.TankDied -= UpdateAchievement;
        }

        public override string Text()
        {
            return "Kill " + neededNumber.ToString("00") + " Tanks.";
        }

        public override void Reset()
        {
            _counter = 0;
        }
    }
}