namespace BattleTank.EnemyTank
{
    public class EnemyTankModel
    {
        public float EnemyHealth;
        public float EnemyMovementSpeed;
        public float EnemyRotationSpeed;
        public EnemyTankType EnemyTankType;

        public EnemyTankController EnemyTankController { get; private set; }

        public void SetTankController(EnemyTankController enemyTankController)
        {
            EnemyTankController = enemyTankController;
        }

        public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject)
        {
            EnemyTankType = enemyTankScriptableObject.EnemyTankType;
            EnemyHealth = enemyTankScriptableObject.EnemyHealth;
            EnemyMovementSpeed = enemyTankScriptableObject.EnemyMovementSpeed;
            EnemyRotationSpeed = enemyTankScriptableObject.EnemyRotationSpeed;
        }
    }
}