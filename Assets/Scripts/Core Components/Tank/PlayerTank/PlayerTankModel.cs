public class PlayerTankModel : TankModel
{
    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base(playerTankScriptableObject.Speed, playerTankScriptableObject.Health, playerTankScriptableObject.Damage, playerTankScriptableObject.FireRate)
    {

    }
}