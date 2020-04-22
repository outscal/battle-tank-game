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
            C_EnemyParent = enemyParent;
            C_EnemyView = GameObject.Instantiate<EnemyView>(enemyPrefab,
                                  enemyModel.M_SpawnPoint.position, enemyModel.M_SpawnPoint.rotation);
            C_EnemyView.Initialize(this);
        }


        public EnemyModel C_EnemyModel { get; private set; }
        public EnemyView C_EnemyView { get; private set; }
        public Transform C_EnemyParent { get; private set; }

        public IModel GetModel()
        {
            return C_EnemyModel;
        }


        public void KillTank()
        {
            Object.Destroy(C_EnemyView.gameObject);
            C_EnemyModel = null;
            C_EnemyView = null;
            C_EnemyParent = null;
        }

        public void OnDeath(ParticleSystem m_ExplosionParticles, Vector3 tankPosition)
        {
            m_ExplosionParticles.transform.position = tankPosition;
            m_ExplosionParticles.gameObject.SetActive(true);

            m_ExplosionParticles.Play();

            EnemyService.Instance.DestroyEnemy(this);
        }
    }
}
