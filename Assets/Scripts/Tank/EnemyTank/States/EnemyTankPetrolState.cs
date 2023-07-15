using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankPetrolState : EnemyTankState
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private int nextPetrolPointIndex = 1;

    private Vector3 petrolPointPos;

    private Vector3 direction;


    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
    private void Update()
    {
        petrolPointPos = tankView.PetrolPoints[nextPetrolPointIndex].transform.position;
        if (Vector3.Distance(transform.position, petrolPointPos) >= 1f)
        {
            direction = petrolPointPos - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
                transform.position = Vector3.MoveTowards(transform.position, petrolPointPos, movementSpeed * Time.deltaTime);
            return;
        }
        nextPetrolPointIndex++;
        if (nextPetrolPointIndex == tankView.PetrolPoints.Count)
            nextPetrolPointIndex = 0;

    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
