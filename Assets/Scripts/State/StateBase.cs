using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace BattleTank
{
	public class StateBase
	{
		public enum STATE { IDLE, PATROL, CHASE, ATTACK }

		public enum EVENT { ENTER, UPDATE, EXIT }

		protected STATE stateName;
		protected EVENT currentStage;
		protected StateBase nextState;
		protected List<Transform> patrollingPoints;
		protected EnemyController enemyController;
		protected NavMeshAgent agent;

		public StateBase(EnemyController _enemyController)
		{
			enemyController = _enemyController;
			//agent = enemyController.GetNavmeshAgent();
			//patrollingPoints = enemyController.GetPatrolPoints();
		}

		public virtual void OnEnter()
		{
			currentStage = EVENT.UPDATE;
		}

		public virtual void OnUpdate()
		{
			currentStage = EVENT.UPDATE;
		}

		public virtual void OnExit()
		{
			currentStage = EVENT.EXIT;
		}

		public StateBase Processing()
		{
			if (currentStage == EVENT.ENTER) { OnEnter(); }
			if (currentStage == EVENT.UPDATE) { OnUpdate(); }
			if (currentStage == EVENT.EXIT)
			{
				OnExit();
				return nextState;
			}
			return this;
		}
	}
}
