using UnityEngine;

class EnemyTankStateChase : EnemyTankState
{

    EnemyTankRangeCollider EnemyTankRangeCollider;

    public EnemyTankStateChase(EnemyTankController enemyTankController) : base(enemyTankController) { }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        EnemyTankModel.CurrentState = EnemyTankStates.Chase;

        EnemyTankRangeCollider = EnemyTankView.gameObject.GetComponentInChildren<EnemyTankRangeCollider>();
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Tick()
    {
        if (EnemyTankRangeCollider != null)
        {
            Transform playerTransform = EnemyTankRangeCollider.PlayerTransform;

            Vector3 position = Vector3.MoveTowards(EnemyTankView.gameObject.transform.position, playerTransform.position, EnemyTankModel.Speed * Time.deltaTime);

            EnemyTankView.Rotation = Quaternion.LookRotation(position);
            EnemyTankView.Position = position;
            EnemyTankView.ApplyTranform = true;
        }

        EnemyTankController.CanSeePlayer();
    }
}