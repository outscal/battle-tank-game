using UnityEngine;
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList playerTankList;
    [SerializeField] FixedJoystick joystick;
    [SerializeField] CameraController mainCamera;
    void Start()
    {
        CreatePlayerTank(Random.Range(0, playerTankList.tanks.Length));
    }
    public void CreatePlayerTank(int index)
    {
        TankScriptableObject tank = playerTankList.tanks[index];
        TankController tankController = new TankController(tank, joystick, mainCamera);
    }
    public void ShootBullet(BulletType bulletType, Transform tankTransform)
    {
        BulletService.Instance.SpawnBullet(bulletType, tankTransform);
    }
    public void DestoryTank(TankView tankView)
    {
        mainCamera.SetTankTransform(null);
        Destroy(tankView.gameObject);
    }
}
