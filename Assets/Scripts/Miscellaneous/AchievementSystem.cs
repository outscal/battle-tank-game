using UnityEngine;
using System;

namespace TankServices
{
    public class AchievementSystem : GenricSingleton<AchievementSystem>
    {
        private void OnEnable()
        {
            ServiceEvents.Instance.OnShoot += ShootObject;
        }

        private void OnDisable()
        {
            ServiceEvents.Instance.OnShoot -= ShootObject;
        }

        public void ShootObject(int count)
        {
            switch (count)
            {
                case 10:
                    {
                        Debug.Log("Achievement  A unlocked");
                        break;
                    }
                case 25:
                    {
                        Debug.Log("Achievement B unlocked");
                        break;
                    }
                case 50:
                    {
                        Debug.Log("Achievement C unlocked");
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

    }
}
