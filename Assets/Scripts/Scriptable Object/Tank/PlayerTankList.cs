using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewPlayerTankList", menuName = "User/Tank/PlayerTankList", order = 0)]
    public class PlayerTankList : TankList
    {
        [SerializeField] private PlayerTank[] list;

        public override Tank[] List => list;
    }
}