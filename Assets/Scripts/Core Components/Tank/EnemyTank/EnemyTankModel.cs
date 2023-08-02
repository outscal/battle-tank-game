public class EnemyTankModel : TankModel
{
    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject) : base(enemyTankScriptableObject.Speed, enemyTankScriptableObject.Health, enemyTankScriptableObject.Damage, enemyTankScriptableObject.FireRate)
    {

    }
}