using Singalton;
using UnityEngine;

namespace Enemy
{
    public class EnemyController
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


        public EnemyModel GetModel()
        {
            return EnemyModel;
        }


        public void KillTank()
        {
            VFXManager.Instance.PlayVFXClip(VFXName.TankExplosion, EnemyView.transform.position, EnemyParent);
            SoundManager.Instance.PlaySoundClip(ClipName.TankExplosion);
            EnemyView.KillView();
            EnemyModel = null;
            EnemyView = null;
            EnemyParent = null;
        }

        public void OnDeath()
        {
            EnemyService.Instance.DestroyEnemy(this);
        }
    }
}
