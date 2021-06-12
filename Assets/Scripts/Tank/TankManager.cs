using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Tank
{
    public class TankManager: MonoBehaviour
    {
        #region Singleton
        public static TankManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public GameObject m_tank;
    }
}