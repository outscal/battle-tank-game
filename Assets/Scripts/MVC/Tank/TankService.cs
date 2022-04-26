public class TankService : MonoGenericSingleton<TankService>
{
    public TankView m_tankView;

    private void Start()
    {
        CreateNewTank();
    }

    private void CreateNewTank()
    {
        //creating a tank model
        TankModel tankModel = new TankModel(5, 100f);

        //spawning the tank using the created tank model
        TankController tankController = new TankController(tankModel, m_tankView);
    }
}