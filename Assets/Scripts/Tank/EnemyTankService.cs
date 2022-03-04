using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class EnemyTankService : SingletonMB<EnemyTankService>, Interfaces.ITankService
    {
        #region Serialized Data members

        [SerializeField] private ParticleSystem tankExplosion;
        [SerializeField] private Scriptable_Object.Tank.EnemyTankList tanks;
        [SerializeField] private Transform[] enemySpawningPoints;

        #endregion

        #region Getters

        public ParticleSystem Explosion => tankExplosion;
        private List<EnemyTankController> _tankControllers = new List<EnemyTankController>();
        public List<EnemyTankController> Tanks => _tankControllers;

        #endregion

        #region Unity Functions

        private void Start()
        {
            foreach (var tank in tanks.List)
            {
                _tankControllers.Add((EnemyTankController) ((Interfaces.ITankService) this).CreateTank(tank));
            }
        }

        #endregion

        #region Private Functions

        private Vector3 GetRandomPosition()
        {
            return enemySpawningPoints[Random.Range(0, enemySpawningPoints.Length - 1)].position;
        }

        #endregion

        TankController Interfaces.ITankService.CreateTank(Scriptable_Object.Tank.Tank tank)
        {
            return new EnemyTankController(tank, GetRandomPosition());
        }

        #region Public Functions

        public void Destroy(TankController controller)
        {
            _tankControllers.Remove((EnemyTankController) controller);
            StartCoroutine(((Interfaces.ITankService) this).KillTank(controller, tankExplosion));
        }

        #endregion
    }
}
