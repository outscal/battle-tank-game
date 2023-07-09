namespace BattleTank.Enemy
{
    public class EnemyModel
    {
        private EnemyController enemyController;

        public int health { get; }
        public int speed { get; }
        public float rotationSpeed { get; }
        public int strength { get; }
        public int bpm { get; }
        public float visibilityRange { get; }
        public float detectionRange { get; }
        public BulletType bulletType { get; }

        public EnemyModel(EnemyScriptableObject enemy)
        {
            health = enemy.health;
            speed = enemy.speed;
            rotationSpeed = enemy.speed / 100f;
            strength = enemy.strength;
            bpm = enemy.bpm;
            visibilityRange = enemy.visibilityRange;
            detectionRange = enemy.detectionRange;
            bulletType = enemy.bulletType;
        }

        public void SetEnemyController(EnemyController _enemyController)
        {
            enemyController = _enemyController;
        }
    }
}
