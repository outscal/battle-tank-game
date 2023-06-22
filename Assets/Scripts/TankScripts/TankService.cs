using UnityEngine;
public enum TankType
{
    Player, Enemy
}
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList tankList;
    [SerializeField] int enemyCount = 2;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] CameraController mainCamera;
    void Start()
    {
        CreatePlayerTank();
        for (int i = 0; i < enemyCount; i++)
            CreateEnemyTank(Random.Range(0, tankList.tanks.Length));
    }
    public void CreatePlayerTank()
    {
        TankScriptableObject tank = tankList.tanks[Random.Range(0, tankList.tanks.Length)];
        TankController tankController = new TankController(tank, TankType.Player, joystick, mainCamera);
    }
    public void CreateEnemyTank(int index)
    {
        TankController tankController = new TankController(tankList.tanks[index], TankType.Enemy, null, null, 10, 4);
    }
}
