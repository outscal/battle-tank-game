using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class ShootState : StateBase
    {
		private float fireRate = 1.5f;
		private float maxBulletVelocity;
		private float bulletVelocityFactor;
		private float timer;

		public ShootState(EnemyController enemy) : base(enemy)
		{
			timer = 0;
			enemy.GetEnemyAgent().isStopped = true;
			maxBulletVelocity = 20f;
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
			if (GetPlayerDistance() > 15)
			{
				nextState = new ChasingState(enemy);
				stage = EVENT.EXIT;
			}
			else
			{
				Shooting(GetPlayerDistance());
			}
		}

		private float GetPlayerDistance()
		{
			return Vector3.Distance(
				enemy.GetPosition(), player.position);
		}

		private void MoveToIdleState()
		{
			nextState = new Idle(enemy);
			stage = EVENT.EXIT;
			return;
		}

		private void Shooting(float distance)
		{
			timer += Time.deltaTime;
			enemy.GetEnemyAgent().transform.LookAt(player.position);
			if (timer >= fireRate)
			{
				enemy.Shoot(enemy.enemyView.GetGun());
				timer = 0;
			}
		}

		/*private float CalculateVelocityFactor(float distance)
		{
			float bulletVelocity = CalculateVelocity(distance);
			bulletVelocityFactor = bulletVelocity / maxBulletVelocity;
			Debug.Log("FireFactor " + bulletVelocity);
			return bulletVelocityFactor;
		}*/
		public override void Exit()
		{
			enemy.GetEnemyAgent().isStopped = false;
			base.Exit();
		}
	}
}
