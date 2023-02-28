using UnityEngine;


// Main Service - create/ instantiate a new tank with tankController component reference

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private int _speed;
    [SerializeField] private int _rotateSpeed;
    [SerializeField] private float _jumpForce;

    // might not be required in tankService
    private TankController tankController;
    private TankModel tankModel;

    // not needed if not doing anything on awake
    protected override void Awake()
    {
        base.Awake();
    }

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

    // passes reference of tankController to new created tank movement service
    public TankController SetTankController()
    {
        return tankController;
    }
}
