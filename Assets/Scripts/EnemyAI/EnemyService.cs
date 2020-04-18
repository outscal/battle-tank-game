using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Bullet;

namespace TankGame.Enemy
{
    public class EnemyService : MonoSingletonGeneric<EnemyService>
    {

        public EnemyView enemyView;
        public EnemyScriptableObjectList EnemyList;
        private Coroutine coroutine;
        //public Color[] enemyColor;
        //public float[] enemyHealth;
        //public float[] enemyDamage;

        private void Start()
        {
            //SpawnEnemy();
        }

        public void fire(Transform bulletSpawn, float bulletDamange)
        {
            BulletService.Instance.spawnBullet(bulletSpawn, bulletDamange);
        } 
        
        public void SpawnEnemy(Vector3 enemySpawnerPos, Quaternion enemySpawnerRotation, int enemyIndex)

        {
            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[enemyIndex]);
            EnemyController controller = new EnemyController(model, enemyView, enemySpawnerPos, enemySpawnerRotation, EnemyList.enemyScriptableObject[enemyIndex]);
        }

        public void DestroyAllEnemies()
        {
            if(coroutine != null)
            {
                StopCoroutine(DestroyAllViews());
            }
          coroutine =  StartCoroutine(DestroyAllViews());
        }

        IEnumerator DestroyAllViews()
        {
            EnemyView[] enemy = GameObject.FindObjectsOfType<EnemyView>();
            foreach (EnemyView enemyTank in enemy)
            {
                yield return new WaitForSeconds(1f);
                ParticleService.Instance.CreateTankExplosion(enemyTank.transform.position, enemyTank.transform.rotation);
                Destroy(enemyTank.gameObject, 0.1f);
            }
        }

        public void DestroyView(EnemyView enemyView)
        {
            ParticleService.Instance.CreateTankExplosion(enemyView.transform.position, enemyView.transform.rotation);

            Destroy(enemyView.gameObject, 0.1f);
        }





        //public void TakeDamage(EnemyView enemy, float damage)
        //{
        //    for (int i = 0; i < EnemyList.enemyScriptableObject.Length; i++)
        //    {
        //        if(enemy.GetController().EnemyModel.EnemyTankType == EnemyList.enemyScriptableObject[i].EnemyType)
        //        {
        //            EnemyList.enemyScriptableObject[i].TankHealth -= damage;
        //            Debug.Log("enemy health= " + EnemyList.enemyScriptableObject[i].TankHealth);
        //            EnemyModel model = new EnemyModel(EnemyList.enemyScriptableObject[i]);
        //            enemy.SetViewDetails(model, EnemyList.enemyScriptableObject[i]);
        //        }
        //    }
        //}
    }
}
