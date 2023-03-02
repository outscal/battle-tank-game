using UnityEngine;

// Main Service - create/ instantiate a new tank with tankController component reference

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private TankType tankType;
    [SerializeField] private TankScriptableObjectList tankList;

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
        CreateNewTank((int)tankType);
    }

    public void CreateNewTank(int index)
    {
        TankScriptableObject tankScriptableObject =  tankList.tanks[index-1];
        tankModel = new TankModel(tankScriptableObject);
        tankController = new TankController(tankModel, tankView);
    }

    // passes reference of tankController to new created tank movement service
    public TankController GetTankController()
    {
        return tankController;
    }
}
