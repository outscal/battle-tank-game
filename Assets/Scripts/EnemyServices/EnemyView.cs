using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using TankServices;
using BulletServices;
using VFXServices;
namespace EnemyServices
{
    public class EnemyView : MonoBehaviour
    {
        public Transform shootingPoint;
        private EnemyController controller;
        public NavMeshAgent navMeshAgent { get; private set; }

        public bool playerDetected; //{ get; private set; }


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
            if (playerDetected)
                controller.Attack();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
                playerDetected = true;
        }
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.GetComponent<BulletView>() != null)
            {
                controller.OnCollisionWithBullet(other.gameObject.GetComponent<BulletView>());
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TankView>() != null)
            {
                playerDetected = false;
            }
        }
        public Transform GetTank()
        {
            return TankService.instance.tankScriptable.tankView.transform;
        }
        public void DestroyView()
        {
            // doubt ?? if we miss something to set to null?? then what are the consecuences ?? how to deal with it?? any solution? 
            shootingPoint = null;
            controller = null;
            navMeshAgent = null;
            VFXService.instance.TankExplosionEffects(transform.position);


            Destroy(this.gameObject);
        }
    }
}