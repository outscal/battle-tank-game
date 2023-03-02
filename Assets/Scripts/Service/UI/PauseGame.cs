using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tanks
{
    public class PauseGame : MonoBehaviour
    {
        public void Pause(bool status)
        {
            if (status)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
