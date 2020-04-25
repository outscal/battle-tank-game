using Singalton;
using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

namespace Enemy
{
    public class EnemyController : IController
    {
        public EnemyController(EnemyModel enemyModel, EnemyView enemyPrefab, Transform enemyParent, Vector3 spawnPos)
        {
            EnemyModel = enemyModel;
            EnemyParent = enemyParent;
            EnemyView = GameObject.Instantiate<EnemyView>(enemyPrefab,
                                  spawnPos, enemyModel.SpawnPointSafe.rotation);
            EnemyView.Initialize(this);
        }


        public EnemyModel EnemyModel { get; private set; }
        public EnemyView EnemyView { get; private set; }
        public Transform EnemyParent { get; private set; }


        public IModel GetModel()
        {
            return EnemyModel;
        }


        public void KillTank()
        {
            EnemyView.KillView();
            EnemyModel = null;
            EnemyView = null;
            EnemyParent = null;
        }

        public void OnDeath(Vector3 tankPosition)
        {
            VFXManager.Instance.PlayVFXClip(VFXName.TankExplosion, tankPosition, EnemyParent);
            SoundManager.Instance.PlaySoundClip(ClipName.TankExplosion);
            EnemyService.Instance.DestroyEnemy(this);
        }
    }
}
