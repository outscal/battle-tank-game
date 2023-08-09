public class PlayerTankModel : TankModel
{
    public PlayerTankView PlayerTankViewPrefab { get; private set; }

    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject) : base((TankScriptableObject)playerTankScriptableObject)
    {
        PlayerTankViewPrefab = playerTankScriptableObject.PlayerTankViewPrefab;
    }
}