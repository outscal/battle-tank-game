using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

namespace BattleTank
{
	public class StateBase
	{
		public enum STATE
		{
			IDLE,
			PATROL,
			CHASE,
			SHOOT
		}

		public enum EVENT
		{
			ENTER,
			UPDATE,
			EXIT
		}

		protected STATE name;
		protected EVENT stage;

		protected StateBase nextState;
		protected EnemyController enemy;
		protected Transform player;
		protected NavMeshAgent agent;

		public StateBase(EnemyController enemy)
		{
			this.enemy = enemy;
			stage = EVENT.ENTER;
			if (TankService.Instance.tankView == null)
            {
				return;
            }
            else {
				player = TankService.Instance.tankView.transform;
			}
				
		}

		public virtual void Enter() { stage = EVENT.UPDATE; }
		public virtual void Update() { stage = EVENT.UPDATE; }
		public virtual void Exit() { stage = EVENT.EXIT; }

		public StateBase Process()
		{
			if (stage == EVENT.ENTER) Enter();
			if (stage == EVENT.UPDATE) Update();
			if (stage == EVENT.EXIT)
			{
				Exit();
				return nextState;
			}
			return this;
		}
    }
}
