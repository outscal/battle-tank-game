using UnityEngine;
public enum TankType
{
    Player, Enemy
}
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList playerTankList;
    [SerializeField] TankScriptableObjectList enemyTankList;
    [SerializeField] int enemyCount = 2;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] CameraController mainCamera;
    void Start()
    {
        CreatePlayerTank(Random.Range(0, playerTankList.tanks.Length));
        for (int i = 0; i < enemyCount; i++)
            CreateEnemyTank(Random.Range(0, enemyTankList.tanks.Length));
    }
    public void CreatePlayerTank(int index)
    {
        TankScriptableObject tank = playerTankList.tanks[index];
        TankController tankController = new TankController(tank, TankType.Player, joystick, mainCamera);
    }
    public void CreateEnemyTank(int index)
    {
        TankScriptableObject tank = enemyTankList.tanks[index];
        TankController tankController = new TankController(tank, TankType.Enemy, null, null, 10, 4);
    }
    public void ShootBullet(BulletType bulletType, Transform tankTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, tankTransform);
    }
    public void DestoryTank(TankView tankView)
    {
        Destroy(tankView.gameObject);
    }
}
