using GlobalServices;
using UnityEngine;

namespace TimerServices
{   
    // Handles time scale value.
    public class TimerHandler : MonoSingletonGeneric<TimerHandler>
    {
        private void Start()
        {
            EventService.Instance.OnGameOver += SetHighTimeScaleValue;
        }

        private void OnDisable()
        {
            EventService.Instance.OnGameOver -= SetHighTimeScaleValue;
        }

        // To set time scale to lower value.
        public void SetLowTimeScaleValue()
        {
            Time.timeScale = 0.2f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        // To set time scale to normal value.
        public void SetHighTimeScaleValue()
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
