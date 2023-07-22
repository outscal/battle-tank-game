using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
	public class PatrolingState : StateBase
	{
		private Vector3 patrolPoint1;
		private Vector3 patrolPoint2;
		private Vector3 currentPoint;

		public PatrolingState(EnemyController enemy) : base(enemy)
		{
			name = STATE.PATROL;
		}

		public override void Enter()
		{
			patrolPoint1 = enemy.spawnPoint + enemy.GetEnemyAgent().transform.forward * 5;
			patrolPoint2 = enemy.spawnPoint - enemy.GetEnemyAgent().transform.forward * 5;
			currentPoint = patrolPoint1;
			base.Enter();
		}

		public override void Update()
		{
			if (player != null)
			{
				if (IsPlayerInChaseRange())
				{
					MoveToChaseState();
					return;
				}
			}

			Patrolling();
		}

		private void MoveToChaseState()
		{
			nextState = new ChasingState(enemy);
			stage = EVENT.EXIT;
		}

		private bool IsPlayerInChaseRange()
		{
			float distance = Vector3.Distance(
					enemy.GetPosition(),
					player.position);
			if (distance < 15)
				return true;

			return false;
		}

		private void Patrolling()
		{
			enemy.GetEnemyAgent().SetDestination(currentPoint);
			if (Vector3.Distance(enemy.GetPosition(), patrolPoint1) < 0.5)
				currentPoint = patrolPoint2;

			if (Vector3.Distance(enemy.GetPosition(), patrolPoint2) < 0.5)
				currentPoint = patrolPoint1;
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
