using UnityEngine;
using System;

namespace TankServices
{
    public class AchievementSystem:MonoBehaviour
    {
        private static AchievementSystem instance;
        public static AchievementSystem Instance
        {
            get
            {
                if (instance == null)
                    instance = new AchievementSystem();
                return instance;
            }
        }

        private void OnEnable()
        {
            Debug.Log("it started wokring");
            ServiceEvents.Instance.OnShoot += ShootObject ;
        }

        private void OnDisable()
        {
            Debug.Log("it ended working");
            ServiceEvents.Instance.OnShoot -= ShootObject;
        }

        public void ShootObject(int count)
        {
            switch(count)
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
