public class TankModel
{
    TankController m_tankController;


    //-----model data/variables-----
    public TankType TankType { get; }
    public string TankName { get; }
    public float Speed { get; }
    public float Health { get; }


    //-----constructor-----
    public TankModel(TankSO tankSO)
    {
        TankType = tankSO.Tanktype;
        TankName = tankSO.TankName;
        Health = tankSO.Health;
        Speed = tankSO.Speed;
    }


    //-----controller reference-----
    public void SetTankController(TankController tankController)
    {
        m_tankController = tankController;
    }
}