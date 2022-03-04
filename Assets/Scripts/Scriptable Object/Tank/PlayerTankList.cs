using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewPlayerTankList", menuName = "User/Tank/PlayerTankList", order = 0)]
    public class PlayerTankList : TankList
    {
        #region Serialized Data members

        [SerializeField] private PlayerTank[] list;

        #endregion

        #region Getters

        public override Tank[] List => list;

        #endregion
    }
}