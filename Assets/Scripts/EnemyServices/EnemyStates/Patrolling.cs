using UnityEngine;

namespace EnemyTankServices
{
    public class Patrolling : EnemyStates
    {
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            tankView.activeState = EnemyState.Patrolling;
        }

        protected override void Start()
        {
            base.Start();
            ChangeWalkPoint();
        }

        private void Update()
        {
            if (tankModel.b_PlayerInSightRange && !tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.chasingState);
            else if (tankModel.b_PlayerInSightRange && tankModel.b_PlayerInAttackRange) tankView.currentState.ChangeState(tankView.attackingState);

            Patroling();
            ResetTurretRotation();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

        private void Patroling()
        {
            if (!tankModel.b_IsWalkPoint) SearchWalkPoint();

            if (tankModel.b_IsWalkPoint)
            {
                tankView.navAgent.SetDestination(tankModel.walkPoint);
            }

            Vector3 distanceToWalkPoint = tankView.transform.position - tankModel.walkPoint;

            if (distanceToWalkPoint.magnitude < 1f)
            {
                tankModel.b_IsWalkPoint = false;
            }
        }

        public async void ChangeWalkPoint()
        {
            while (true)
            {
                await new WaitForSeconds(tankModel.patrolTime);
                tankModel.b_IsWalkPoint = false;
            }
        }

        private void SearchWalkPoint()
        {
            float randomZ = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);
            float randomX = Random.Range(-tankModel.walkPointRange, tankModel.walkPointRange);

            tankModel.walkPoint = new Vector3(tankView.transform.position.x + randomX, tankView.transform.position.y, tankView.transform.position.z + randomZ);

            if (Physics.Raycast(tankModel.walkPoint, -tankView.transform.up, 2f, tankView.groundLayerMask))
            {
                tankModel.b_IsWalkPoint = true;
            }
        }

        private void ResetTurretRotation()
        {
            if (tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y > 1
                || tankView.turret.transform.rotation.eulerAngles.y - tankView.transform.rotation.eulerAngles.y < -1)
            {
                Vector3 desiredRotation = Vector3.up * tankModel.turretRotationRate * Time.deltaTime;
                tankView.turret.transform.Rotate(desiredRotation, Space.Self);
            }
        }
    }
}
