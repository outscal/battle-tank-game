using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTank
{
    [RequireComponent(typeof(Image))]
    public class TankView : MonoBehaviour, IDamageable
    {
        private TankController tankController;
        public TankType TankType;
        private Image image;

        private TankState currentState;

        [SerializeField]
        public TankPatrollingState patrollingState;

        [SerializeField]
        public TankChasingState chasingingState;

        [SerializeField]
        private TankState startingStaste;

        private void Awake()
        {
            image = GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("Image not found");
            }
        }

        private void Start()
        {
            ChangeState(startingStaste);

            Debug.Log("Tank view Created");

            if (image != null)
            {
                Debug.Log("Image Found");
            }
        }

        private void Initalise(TankController tankController)
        {
            this.tankController = tankController;
        }

        internal void Enabled()
        {
            gameObject.SetActive(true);
        }

        internal void Disabled()
        {
            gameObject.SetActive(false);
        }

        internal void ChangeColor(Color color)
        {
            image.color = color;
        }

        public void ChangeState(TankState newState)
        {
            if (currentState = newState)
            {
                currentState.OnExitState();
            }

            currentState = newState;
            currentState.OnEnterState();
        }

        public void TakeDamage(BulletType bulletType, int damage)
        {
            Debug.Log("Taking Damage : " + damage + " From Bullet: " + bulletType);
            tankController.ApplyDamage(bulletType, damage);
        }

        public void Initialise(TankController tankController)
        {
            this.tankController = tankController;
        }
    }
}