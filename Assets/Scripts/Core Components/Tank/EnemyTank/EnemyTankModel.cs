public class EnemyTankModel : TankModel
{

    public short SpawnChance { get; private set; }

    public EnemyTankView EnemyTankViewPrefab { get; private set; }

    public EnemyTankStates CurrentState { get; set; }

    public EnemyTankModel(EnemyTankScriptableObject enemyTankScriptableObject) : base((TankScriptableObject)enemyTankScriptableObject)
    {
        SpawnChance = enemyTankScriptableObject.SpawnChance;

        EnemyTankViewPrefab = enemyTankScriptableObject.EnemyTankViewPrefab;

        CurrentState = EnemyTankStates.None;
    }
}