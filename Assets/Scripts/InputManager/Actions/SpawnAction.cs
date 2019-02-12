using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Inputs
{
    public class SpawnAction : InputAction
    {
        Vector3 spawnPos;

        public SpawnAction(Vector3 spawnPos)
        {
            this.spawnPos = spawnPos;
        }

        public override void Execute()
        {
            PlayerManager.Instance.playerController.setIdleState(0, 0);
            PlayerManager.Instance.playerController.setSpawnPos(spawnPos);
            Debug.Log("[SpawnAction] Position:" + spawnPos);
        }
    }
}