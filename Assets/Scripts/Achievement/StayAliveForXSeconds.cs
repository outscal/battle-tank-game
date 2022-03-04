using Tank;
using UnityEngine;

namespace Achievement
{
    public class StayAliveForXSeconds:Achievement
    {
        #region Serialized Data members

        [SerializeField] private float neededTime = 20f;

        #endregion

        #region Private Data members;

        private float _counter;
        private bool _alive;

        #endregion

        #region Protected Functions

        protected override void UpdateAchievement()
        {
            InvokeAchievement(this);
        }

        #endregion

        #region Unity Functions

        

        #endregion

        #region Constructors
        

        #endregion

        #region Private Functions

        private async void StartCounting()
        {
            _alive = true;
            while (_alive)
            {
                await new WaitForSeconds(Time.deltaTime);
                _counter += Time.deltaTime;
                if (_counter >= neededTime)
                {
                    UpdateAchievement();
                    Unsubscribe();
                    break;
                }
            }
        }

        private void StopCounting()
        {
            _alive = false;
            Unsubscribe();
        }

        #endregion
        #region Public Functions

        public override void Subscribe()
        {
            PlayerTankService.PlayerCreated += StartCounting;
            PlayerTankService.LoseLife += StopCounting;
        }

        public override void Unsubscribe()
        {
            PlayerTankService.PlayerCreated -= StartCounting;
            PlayerTankService.LoseLife -= StopCounting;
        }

        public override string Text()
        {
            return "Stay Alive for " + neededTime.ToString("00,00") + " seconds.";
        }

        public override void Reset()
        {
            _counter = 0;
        }

        #endregion
    }
}