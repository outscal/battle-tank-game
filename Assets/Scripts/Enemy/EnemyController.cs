using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Manager;
using Interfaces;

namespace Enemy
{
    public enum EnemyState { petrol, chase, coolDown }

    public class EnemyController : IPoolable
    {
        public EnemyView enemyView { get; private set; }
        public EnemyModel enemyModel { get; private set; }

        public event Action DestroyEnemy;
        private EnemyState enemyState = EnemyState.petrol;

        public EnemyState EnemyState { get { return enemyState; } }

        private EnemyState lastStateView, currentStateView;

        private EnemyData enemyData;

        public EnemyData EnemyData { get { return enemyData; } }

        private IGameManager gameManager;
        private IEnemy enemyManager;

        public EnemyController()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            if (enemyManager == null)
                enemyManager = StartService.Instance.GetService<IEnemy>();

            //enemyManager.AlertMode += GetAlerted;
            //gameManager.game
        }

        public void SetEnemyPosition(Vector3 position)
        {
            enemyView.transform.position = position;
        }

        public void SetEnemyModel(ScriptableObjEnemy scriptableObjEnemy)
        {
            if(enemyModel == null)
            {
                enemyModel = new EnemyModel();
                enemyModel.scriptableObj = scriptableObjEnemy;
                enemyModel.CurrentHealth = enemyModel.scriptableObj.health;
            }
            if (enemyView == null)
            {
                GameObject enemy = GameObject.Instantiate<GameObject>(enemyModel.scriptableObj.enemyView.gameObject);
                enemyView = enemy.GetComponent<EnemyView>();
                enemyView.SetEnemyController(this);
            }

            enemyManager.AlertMode += GetAlerted;
            enemyView.TargetDetected += SendAlert;
            enemyView.StateChangedEvent += ChangeState;
            ChangeState(EnemyState.petrol);
        }

        public void SetEnemyIndex(int enemyIndex)
        {
            enemyView.enemyIndex = enemyIndex;

            if (gameManager.GetCurrentState().gameStateType == StateMachine.GameStateType.Replay)
            {
                enemyData = new EnemyData();
                enemyData = enemyManager.GetEnemyData(enemyIndex);
                //for (int i = 0; i < enemyData.wayPoints.Count; i++)
                //{
                //    Debug.Log("[EnemyController] WayPoint" + i + " " + enemyData.wayPoints[i]);
                //}
            }
        }

        public void TakeDamage(int value)
        {
            enemyModel.CurrentHealth -= value;
            if (enemyModel.CurrentHealth <= 0)
            {
                DestroyEnemy?.Invoke();
                Reset();
            }
        }

        public void ChangeState(EnemyState enemyState)
        {
            lastStateView = currentStateView;

            currentStateView = enemyState;

            if (currentStateView == EnemyState.petrol)
                enemyView.PetrolState.enabled = true;
            else if (currentStateView == EnemyState.chase)
                enemyView.ChaseState.enabled = true;
        }

        public void RemoveAlertMode()
        {
            enemyManager.AlertMode -= GetAlerted;
            //Debug.Log("[EnemyController] AlertMode removed");
        }

        void GetAlerted(Vector3 position)
        {
            enemyView.FollowTarget(position);
        }

        void SendAlert(Vector3 position)
        {
            enemyManager.AlertEnemies(position);
        }

        public int getScoreIncreaser()
        {
            return enemyModel.scriptableObj.scoreIncrease;
        }

        public void Reset()
        {
            enemyView.TargetDetected -= SendAlert;
            enemyView.StateChangedEvent -= ChangeState;
            enemyManager.AlertMode -= GetAlerted;
            //enemyView.ResetEnemyView();
            //enemyModel = null;
        }

        public int GetScoreIncreaser()
        {
            return enemyModel.scriptableObj.scoreIncrease;
        }
    }
}