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

        public override void Execute(int shooterID)
        {
            PlayerManager.Instance.playerControllerList[shooterID].setIdleState(0, 0);
            PlayerManager.Instance.playerControllerList[shooterID].setSpawnPos(spawnPos);
            Debug.Log("[SpawnAction] Position:" + spawnPos);
        }
    }
}