using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    public TankView tankView;

    void Start()
    {
        Createtank();
    }

    private void Createtank()
    {
        TankModel tankModel = new TankModel(10, 50f, TankType.MediumTank, BulletType.Standard);
        TankController tankController = new TankController(tankModel, tankView);
    }
}
