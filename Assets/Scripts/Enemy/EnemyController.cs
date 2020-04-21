using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : IController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab, Transform enemyParent)
        {
            C_EnemyModel = enemyModel;
            C_TankParent = enemyParent;
            C_EnemyView = GameObject.Instantiate<EnemyView>(enemyPrefab,
                                  enemyModel.M_SpawnPoint.position, enemyModel.M_SpawnPoint.rotation);
            C_EnemyView.Initialize(this);
        }


        public EnemyModel C_EnemyModel { get; private set; }
        public EnemyView C_EnemyView { get; private set; }
        public Transform C_TankParent { get; }

        public IModel GetModel()
        {
            return C_EnemyModel;
        }

        public void OnDeath(ParticleSystem m_ExplosionParticles, Vector3 tankPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}
