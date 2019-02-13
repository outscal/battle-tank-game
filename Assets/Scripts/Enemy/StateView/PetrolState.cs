using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BTManager;

namespace Enemy
{
    public class PetrolState : EnemyBaseStateView
    {
        [SerializeField] private EnemyView enemyView;

        private List<Vector3> wayPointList;

        private int currentWayPointIndex;

        [SerializeField]
        private float moveLimit;

        private int replayIndexCOunt = 0;

        protected override void OnEnable()
        {
            base.OnEnable();


            Debug.Log(this.name + " is in PetrolState");
            wayPointList = new List<Vector3>();

            foreach (var wayPoint in FindObjectsOfType<WayPoints>())
            {
                wayPointList.Add(wayPoint.GetComponent<Transform>().position);
            }

            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
            {
                SelectWayPoint();
            }
            else if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Replay)
            {
                currentWayPointIndex = EnemyManager.Instance.EnemyDatas[enemyView.enemyIndex].wayPoints[replayIndexCOunt];
                replayIndexCOunt++;
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
            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
            {
                EnemyData enemyData = new EnemyData();
                enemyData.wayPoints = new List<int>();
                enemyData = EnemyManager.Instance.EnemyDatas[enemyView.enemyIndex];
                enemyData.wayPoints.Add(r);
                EnemyManager.Instance.EnemyDatas[enemyView.enemyIndex] = enemyData;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Pause) return;

            if (wayPointList.Count == 0) return;

            if (Vector3.Distance(wayPointList[currentWayPointIndex], transform.position) < 1f)
            {
                if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Game)
                {
                    SelectWayPoint();
                }
                else if (GameManager.Instance.currentState.gameStateType == StateMachine.GameStateType.Replay)
                {
                    currentWayPointIndex = EnemyManager.Instance.EnemyDatas[enemyView.enemyIndex].wayPoints[replayIndexCOunt];
                    replayIndexCOunt++;
                }
            }

            var direction = wayPointList[currentWayPointIndex] - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 1f * Time.deltaTime);
            transform.Translate(new Vector3(0, 0, Time.deltaTime * 2f));

        }
    }
}