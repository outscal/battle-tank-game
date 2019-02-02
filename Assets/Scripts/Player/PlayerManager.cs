using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Common;
using UnityEngine.SceneManagement;
using UI;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputComponentScriptableList inputComponentScriptableList;

        public PlayerController playerController { get; private set; }




        public void SpawnPlayer()
        {
            if(inputComponentScriptableList==null)
            {
                Debug.Log("[PlayerManager] Missing InputComponentScriptableList");
            }

            int r = Random.Range(0, inputComponentScriptableList.inputComponentScriptables.Count);
            playerController = new PlayerController(inputComponentScriptableList.inputComponentScriptables[r]);
        }

        public void DestroyPlayer(PlayerController _playerController)
        {
            _playerController.DestroyPlayer();
            _playerController = null;
        }

        public void DamagePlayer(PlayerController _playerController)
        {

        }

        //public void 
    }
}