using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BattleTank
{
    public class GameUI : MonoBehaviour
    {
        private int myId;

        public event Action OnDeath;     //Event

        public event Action<int, int> onDeath;

        private void Start()
        {
            OnDeath += GameUI_OnDeath;   //subscribe (on other script)
            onDeath += GameUI_onDeath;
            //OnDeath.Invoke();  //INVOKE

            OnDeath?.Invoke();   //null check on event

            onDeath?.Invoke(0, 100);
        }

        private void GameUI_onDeath(int idTankDead, int idTankKilled)
        {
            if (idTankDead == myId)
            {
                //
            }
            else if (idTankDead == myId)
            {

            }
        }

        private void GameUI_OnDeath()
        {
            throw new NotImplementedException();
        }

        private void OnDestroy()
        {
            OnDeath -= GameUI_OnDeath;
            onDeath -= GameUI_onDeath;
        }
    }
}