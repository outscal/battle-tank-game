using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyTankController
{
    public EnemyTankModel TankModel { get; }
    public EnemyTankView TankView { get; }

    float byDefaultEnemyHealth;

    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab)
    {
        TankModel = tankModel;
        TankView = GameObject.Instantiate<EnemyTankView>(tankPrefab);
        TankView.enemyTankController = this;
    }
    public void UpdateEnemyTankPatrolling1()
    {
        if (TankView != null)
        {
            TankView.playerInSightRange = Physics.CheckSphere(TankView.transform.position, TankView.sightRange, TankView.playerTank);
            TankView.playerInAttackRange = Physics.CheckSphere(TankView.transform.position, TankView.sightRange, TankView.playerTank);
            if (!TankView.playerInSightRange && !TankView.playerInAttackRange) Patrolling();
            if (TankView.playerInAttackRange && TankView.playerInSightRange) AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!TankView.walkPointSet)
            SearchWalkPoint();
        if (TankView.walkPointSet)
            TankView.navMeshAgent.SetDestination(TankView.walkPoint);
        Vector3 distanceToWalkPoint = TankView.transform.position - TankView.walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
            TankView.walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-TankView.walkPointRange, TankView.walkPointRange);
        float randomX = Random.Range(-TankView.walkPointRange, TankView.walkPointRange);
        TankView.walkPoint = new Vector3(TankView.transform.position.x + randomX, TankView.transform.position.y, TankView.transform.position.z + randomZ);
        if (Physics.Raycast(TankView.walkPoint, -TankView.transform.up, 2f, TankView.groundMask))
            TankView.walkPointSet = true;

    }

    private async void AttackPlayer()
    {
        TankView.navMeshAgent.SetDestination(TankView.transform.position);
        Vector3 forward = TankView.Turret.transform.TransformDirection(Vector3.forward);
        Vector3 desiredRotation = new Vector3(0, 0, 0);

        if (!Physics.Raycast(TankView.transform.position, forward, TankView.attackrange, TankView.playerTank))
        {
            Vector3 targetDirection = TankView.tankPlayer.position - TankView.Turret.transform.position;
            float angle = Vector3.SignedAngle(targetDirection, TankView.Turret.transform.forward, Vector3.up);

            if (angle < 0)
            {
                desiredRotation = Vector3.up * TankView.turretRotationRate * Time.deltaTime;
            }
            else if (angle > 0)
            {
                desiredRotation = -Vector3.up * TankView.turretRotationRate * Time.deltaTime;
            }

            TankView.Turret.transform.Rotate(desiredRotation, Space.Self);
        }
        else if (!TankView.isAttacked)
        {
            TankView.isAttacked = true;
            ShotEnemyBullet();
            //await new WaitForSeconds(TankView.fireTime);
            ResetAttack();
        }

    }

    private void ShotEnemyBullet()
    {
        BulletService.Instance.CreateBullet(TankView.BulletEmitter);
    }

    private void ResetAttack()
    {
        TankView.isAttacked = false;
    }

    public void SetEnemyHealthUI()
    {
        TankView.healthSlider.value = TankModel.Health;
        TankView.healthFillImage.color = Color.Lerp(TankView.minHealthColour, TankView.maxHealthColour, TankModel.Health / byDefaultEnemyHealth);
    }

    public void TakeDamage(int damage)
    {
        byDefaultEnemyHealth = TankModel.Health;
        TankModel.Health -= damage;
        SetEnemyHealthUI();
        if (TankModel.Health <= 0f && !TankView.isEnemyTankLive)
        {
            OnEnemyDeath();
        }
    }

    public void OnEnemyDeath()
    {
        TankView.isEnemyTankLive = true;
        TankView.explosionParticles.transform.position = TankView.transform.position;
        TankView.explosionParticles.gameObject.SetActive(true);
        TankView.explosionParticles.Play();
        TankView.explosionSound.Play();
        TankView.DestroyEnemyTank();
    }

}