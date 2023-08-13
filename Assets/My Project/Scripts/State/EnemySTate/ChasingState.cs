using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class ChasingState : StateBase
    {
		public ChasingState(EnemyController enemy) : base(enemy)
		{
			name = STATE.CHASE;
		}

		public override void Enter()
		{
			base.Enter();
		}

		public override void Update()
		{
			if (player == null)
			{
				MoveToIdleState();
				return;
			}

			enemy.GetEnemyAgent().SetDestination(TankService.Instance.tankView.transform.position);

			float distance = Vector3.Distance(
				enemy.GetPosition(), TankService.Instance.tankView.transform.position);

			if (distance > 20)
			{
				MoveToIdleState();
			}
			else if (distance < 10)
			{
				nextState = new ShootState(enemy);
				stage = EVENT.EXIT;
			}
		}

		private void MoveToIdleState()
		{
			nextState = new Idle(enemy);
			stage = EVENT.EXIT;
		}

		public override void Exit()
		{
			base.Exit();
		}
	}
}
