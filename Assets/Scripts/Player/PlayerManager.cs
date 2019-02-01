using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using Common;

namespace Player
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        public InputComponentScriptableList inputComponentScriptableList;

        public PlayerController playerController { get; private set; }

        // Use this for initialization
        void Start()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
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
    }
}