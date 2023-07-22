using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace BattleTank
{
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
        [SerializeField]
        private NavMeshAgent agent;
        [SerializeField] Rigidbody rb;
        [SerializeField] Transform gun;
        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
        public Rigidbody GetRigidbody()
        {
            return rb;
        }
        public int GetEnemyStrength()
        {
            return enemyController.GetStrength();
        }
        public void TakeDamage(int damage)
        {
            enemyController.TakeDamage(damage);
        }
        public NavMeshAgent GetAgent()
        {
            return agent;
        }
        public Transform GetGun()
        {
            return gun;
        }
    }
}