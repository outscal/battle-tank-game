using UnityEngine;

namespace BattleTank.Enemy
{
    public class EnemyController
    {
        public EnemyModel enemyModel { get; }
        public EnemyView enemyView { get; }

        private Transform playerTransform;
        private int health;

        public EnemyController(EnemyScriptableObject enemyData, Vector3 randomPosition, Transform playerTransform)
        {
            enemyView = GameObject.Instantiate<EnemyView>(enemyData.enemyView, randomPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
            enemyModel = new EnemyModel(enemyData);

            enemyView.SetEnemyController(this);
            enemyModel.SetEnemyController(this);

            health = enemyModel.health;
            this.playerTransform = playerTransform;
        }

        public int GetStrength()
        {
            return enemyModel.strength;
        }

        public float GetVisibilityRange()
        {
            return enemyModel.visibilityRange;
        }

        public float GetDetectionRange()
        {
            return enemyModel.detectionRange;
        }

        public float GetBulletsPerMinute()
        {
            return enemyModel.bpm;
        }

        public float GetSpeed()
        {
            return enemyModel.speed;
        }

        public float GetRotationSpeed()
        {
            return enemyModel.rotationSpeed;
        }

        public Vector3 GetPosition()
        {
            return enemyView.transform.position;
        }

        public Transform GetPlayerTransform()
        {
            return playerTransform;
        }

        public void Shoot(Transform gunTransform)
        {
            EnemyService.Instance.ShootBullet(enemyModel.bulletType, gunTransform);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0)
                EnemyDeath();
        }

        private void EnemyDeath()
        {
            EnemyService.Instance.DestoryEnemy(this);
        }
    }
}
