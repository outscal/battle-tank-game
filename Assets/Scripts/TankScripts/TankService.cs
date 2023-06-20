using UnityEngine;
public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankView tankPrefab;
    void Start()
    {
        CreateNewTank();
    }
    public void CreateNewTank()
    {
        TankController tankController = new TankController(tankPrefab);
    }
}
