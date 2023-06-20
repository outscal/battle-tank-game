using UnityEngine;
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankView tankPrefab;
    [SerializeField] FixedJoystick joystick;
    void Start()
    {
        CreatePlayerTank();
    }
    public void CreatePlayerTank()
    {
        TankController tankController = new TankController(tankPrefab, joystick, 10, 100);
    }
}
