using UnityEngine;

public class EnemyTankPetrolState : EnemyTankState
{
   
    [SerializeField]
    private int nextPetrolPointIndex = 1;

    private Vector3 petrolPointPos;
        


    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
    private void Update()
    {
        petrolPointPos = tankView.PetrolPoints[nextPetrolPointIndex].transform.position;
        if (Vector3.Distance(transform.position, petrolPointPos) >= 1f)
        {
            Quaternion targetRotation = tankController.RotateTank(petrolPointPos);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
                tankController.MoveTank(petrolPointPos);
            return;
        }
        nextPetrolPointIndex++;
        if (nextPetrolPointIndex == tankView.PetrolPoints.Count)
            nextPetrolPointIndex = 0;
        tankView.ChangeState(tankView.idleState);
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
    }
}
