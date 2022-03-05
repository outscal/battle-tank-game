using Tank;
using UnityEngine;

namespace Achievement
{
    public class StayAliveForXSeconds:Achievement
    {
        #region Serialized Data members

        [SerializeField] private float counterFrequency = 0.2f;
        [SerializeField] private int neededTime = 65;

        #endregion

        #region Private Data members;

        private float _counter;
        private bool _alive;

        #endregion

        #region Protected Functions

        protected override void UpdateAchievement()
        {
            Debug.Log("Stay Alive Achieved!");
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
                await new WaitForSeconds(counterFrequency);
                _counter += counterFrequency;
                if (_counter >= neededTime)
                {
                    UpdateAchievement();
                    break;
                }
            }
            Unsubscribe();
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
            int mins = neededTime / 60;
            int secs = neededTime - (mins * 60);
            string time = $"{mins:00}:{secs:00}";
            return "Stay Alive for " + time + " Minutes.";
        }

        public override void Reset()
        {
            _counter = 0;
            _alive = true;
        }

        #endregion
    }
}