using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Interfaces;

namespace Enemy
{
    public class PetrolView : EnemyBaseStateView
    {
        [SerializeField] private EnemyView enemyView;

        private List<Vector3> wayPointList;

        private int currentWayPointIndex;

        private Vector3 currentTargetPos;

        [SerializeField]
        private float moveLimit;

        private int replayIndexCOunt = 0;

        private IGameManager gameManager;

        protected override void OnEnable()
        {
            base.OnEnable();

            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            enemyView.ChaseState.enabled = false;

            //Debug.Log(this.name + " is in PetrolState");
            wayPointList = new List<Vector3>();

            foreach (var wayPoint in FindObjectsOfType<WayPoints>())
            {
                wayPointList.Add(wayPoint.GetComponent<Transform>().position);
            }

            if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Game)
            {
                SelectWayPoint();
            }
            else if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Replay)
            {
                enemyView.Agent.destination = enemyView.GetEnemyController().EnemyData.wayPoints[replayIndexCOunt];
                currentTargetPos = enemyView.GetEnemyController().EnemyData.wayPoints[replayIndexCOunt];
                replayIndexCOunt++;
                if (replayIndexCOunt > enemyView.GetEnemyController().EnemyData.wayPoints.Count)
                    replayIndexCOunt = 0;
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
        }

        void SelectWayPoint()
        {
            int r = Random.Range(0, wayPointList.Count);
            while (r == currentWayPointIndex)
            {
                r = Random.Range(0, wayPointList.Count);
            }
            currentWayPointIndex = r;
            enemyView.Agent.destination = wayPointList[currentWayPointIndex];
            currentTargetPos = wayPointList[currentWayPointIndex];;
            if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Game)
            {
                enemyView.SetEnemyData(wayPointList[currentWayPointIndex]);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Pause)
            {
                if (enemyView.Agent.isStopped == false)
                    enemyView.Agent.isStopped = true;

                return;
            }
            else if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Game)
            {
                if (enemyView.Agent.isStopped == true)
                    enemyView.Agent.isStopped = false;
            }

            if (wayPointList.Count == 0) return;

            if (enemyView.Agent.remainingDistance <= 0.5f)
            {
                //Debug.Log("[PetrolView] Target Changed 1");

                if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Game)
                {
                    //Debug.Log("[PetrolView] Target Changed");
                    SelectWayPoint();
                }
                else if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Replay)
                {
                    enemyView.Agent.destination = enemyView.GetEnemyController().EnemyData.wayPoints[replayIndexCOunt];
                    currentTargetPos = enemyView.GetEnemyController().EnemyData.wayPoints[replayIndexCOunt];
                    //Debug.Log("[PetrolView] Target Changed:" + currentTargetPos);
                    replayIndexCOunt++;
                    if (replayIndexCOunt > enemyView.GetEnemyController().EnemyData.wayPoints.Count)
                        replayIndexCOunt = 0;
                }
            }
        }
    }
}