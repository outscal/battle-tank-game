using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewPlayerTank", menuName = "User/Tank/PlayerTank", order = 2)]
    public class PlayerTank:Tank
    {
        #region Serialized Data members

        [SerializeField] private PlayerTankView tankView;

        #endregion

        #region Constructors

        PlayerTank()
        {
            tankType = TankType.Player;
            tankModel = new PlayerTankModel();
        }

        #endregion

        #region Getters

        public override TankView TankView => tankView;

        #endregion
    }
}