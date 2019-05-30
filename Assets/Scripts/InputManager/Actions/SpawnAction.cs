using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace InputControls
{
    public class SpawnAction : InputAction
    {
        Vector3 spawnPos;

        public SpawnAction(Vector3 spawnPos)
        {
            this.spawnPos = spawnPos;
        }

        public override void Execute(PlayerController playerController)
        {
            playerController.setIdleState(0, 0);
            playerController.setSpawnPos(spawnPos);
            Debug.Log("[SpawnAction] Position:" + spawnPos);
        }
    }
}