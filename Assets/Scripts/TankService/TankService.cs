using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private float _jumpForce;

    // might not be required in tankService
    private TankController tankController;
    private TankModel tankModel;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        CreateNewTank();
    }

    public void CreateNewTank()
    {
        tankModel = new TankModel(_speed, _rotateSpeed, _jumpForce);
        tankController = new TankController(tankModel, tankView);
    }

    public TankController SetTankController()
    {
        return tankController;
    }
}
