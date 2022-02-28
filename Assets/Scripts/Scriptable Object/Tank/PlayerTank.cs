using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewPlayerTank", menuName = "User/Tank/PlayerTank", order = 2)]
    public class PlayerTank:Tank
    {
        [SerializeField] private PlayerTankView _tankView;
        public override TankView TankView => _tankView;

        PlayerTank()
        {
            tankType = TankType.Player;
            tankModel = new TankModel();
        }
    }
}