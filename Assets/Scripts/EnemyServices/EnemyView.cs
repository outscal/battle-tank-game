using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using TankServices;
using BulletServices;
namespace EnemyServices
{
    public class EnemyView : MonoBehaviour
    {
        public Transform shootingPoint;
        private EnemyController controller;
        public NavMeshAgent navMeshAgent { get; private set; }
        public bool playerDetected; //{ get; private set; }
        private Transform tank;


        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        public void SetEnemyController(EnemyController _controller)
        {
            controller = _controller;
        }

        private void Update()
        {
            Debug.Log(controller.currentState);
            controller.Movement();
            controller.Attack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                playerDetected = true;
                Debug.Log(playerDetected);
            }
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<BulletView>() != null)
            {
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                playerDetected = false;
                Debug.Log(playerDetected);
            }
        }
        public Transform GetTank()
        {
            return TankService.instance.tankScriptable.tankView.transform;
        }
    }
}