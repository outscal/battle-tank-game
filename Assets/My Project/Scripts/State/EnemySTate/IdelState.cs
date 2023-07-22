using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	public class Idle : StateBase
	{
		public Idle(EnemyController enemy) : base(enemy)
		{
			name = STATE.IDLE;
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			if (IsPlayerInChaseRange())
			{
				MoveToChaseState();
				return;
			}

			if (IsEnemyAwayFromSpawn())
			{
				// Go back to original position
				enemy.GetEnemyAgent().SetDestination(enemy.spawnPoint);
			}
			else
			{
				// 10 in 5000 chance that enemy goes to Patrol state
				if (Random.Range(0, 5000) < 10)
				{
					nextState = new PatrolingState(enemy);
					stage = EVENT.EXIT;
				}
			}
		}

		private void MoveToChaseState()
		{
			nextState = new ChasingState(enemy);
			stage = EVENT.EXIT;
		}
		private bool IsPlayerInChaseRange()
		{
			if (player == null)
				return false;

			float distance = Vector3.Distance(
				enemy.GetPosition(),
				player.position);
			if (distance < 15)
				return true;

			return false;
		}
		private bool IsEnemyAwayFromSpawn() =>
			Vector3.Distance(enemy.GetPosition(), enemy.spawnPoint) > 0.5;
		public override void Exit()
		{
			base.Exit();
		}
	}
}