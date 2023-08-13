using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class ShootState : StateBase
    {
		private float shootCooldown;
		public ShootState(EnemyController _enemyController) : base(_enemyController)
		{
			name = STATE.SHOOT;
		}
		public override void Enter()
		{
			//agent.isStopped = true;
			base.Enter();
		}
		public override void Update()
		{
			if (!enemy.IsPlayerInShootRange())
			{
				EnterPatrolState();
				return;
			}
			enemy.ShootingPlayerTank();
		}

		private void EnterPatrolState()
		{
			nextState = new PatrolingState(enemy);
			stage = EVENT.EXIT;
		}
	}
}
