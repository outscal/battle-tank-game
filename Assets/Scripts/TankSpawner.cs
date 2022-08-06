using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public TankView tankPrefab;

    private void Start()
    {
        CreateTank();
    }

    private void CreateTank()
    {
        TankModel tankModel = new TankModel();
        TankController tankController = new TankController(tankModel, tankPrefab);
    }
}
