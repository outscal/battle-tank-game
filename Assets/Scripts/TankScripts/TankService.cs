using UnityEngine;
public enum TankType
{
    Player, Enemy
}
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] int enemyCount = 2;
    [SerializeField] TankView tankPrefab;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] CameraController mainCamera;
    void Start()
    {
        CreatePlayerTank();
        for (int i = 0; i < enemyCount; i++)
            CreateEnemyTank();
    }
    public void CreatePlayerTank()
    {
        TankController tankController = new TankController(tankPrefab, 10, 100, TankType.Player, joystick, mainCamera);
    }
    public void CreateEnemyTank()
    {
        TankController tankController = new TankController(tankPrefab, 5, 100, TankType.Enemy, null, null, 10, 4);
    }
}
