
using System;
using UnityEngine;

public class EnemyTankController 
{
    public EnemyTankModel tankModel;
    public EnemyTankView tankView;
    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankView)
    {
        this.tankModel = tankModel;
        this.tankView = tankView;
    }

    public void TakeDamage(float power)
    {
        tankModel.health -= power;
        if(tankModel.health<=0)
        {
            TankDestroy();
        }
    }

    public void ChangeStateBasedOnPlayer()
    {
        float distanceToPlayer = Vector3.Distance(tankView.transform.position, tankView.PlayerTank.transform.position);
        if (distanceToPlayer > tankView.fightRadius && distanceToPlayer <= tankView.chaseRadius && tankView.currentState!=tankView.chaseState)
            tankView.ChangeState(tankView.chaseState);
        else if (distanceToPlayer <= tankView.fightRadius && tankView.currentState != tankView.fightState)
            tankView.ChangeState(tankView.fightState);
        else if (distanceToPlayer > tankView.chaseRadius &&tankView.currentState != tankView.petrolState)
            tankView.ChangeState(tankView.petrolState);
    }

    private void TankDestroy()
    {
        GameObject.Destroy(tankView.gameObject);
    }

    public Quaternion RotateTank(Vector3 targetPos)
    {
        Vector3 direction = targetPos - tankView.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        tankView.transform.rotation = Quaternion.Lerp(tankView.transform.rotation, targetRotation, Time.deltaTime * tankView.rotationSpeed);
        return targetRotation;
    }

    public void MoveTank(Vector3 targetPos)
    {
        tankView.transform.position = Vector3.MoveTowards(tankView.transform.position, targetPos, tankView.movementSpeed * Time.deltaTime);
    }
}
