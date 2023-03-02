using UnityEngine;

namespace TankBattle.TankService
{

    // Main Service - create/ instantiate a new tank with tankController component reference

    public class TankService : GenericSingleton<TankService>
    {
        [SerializeField] private PlayerTank.TankView tankView;
        [SerializeField] private TankType tankType;
        [SerializeField] private TankScriptableObjectList tankList;

        // might not be required in tankService
        private PlayerTank.TankController tankController;
        private PlayerTank.TankModel tankModel;


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
            TankScriptableObject tankScriptableObject = tankList.tanks[index - 1];
            tankModel = new PlayerTank.TankModel(tankScriptableObject);
            tankController = new PlayerTank.TankController(tankModel, tankView);
        }

        // passes reference of tankController to new created tank movement service
        public PlayerTank.TankController GetTankController()
        {
            return tankController;
        }
    }
}