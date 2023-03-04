using UnityEngine;

namespace TankBattle.TankService.EnemyService
{
    public class EnemyService : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            TankService.Instance.CreateEnemyTank();
        }
    }
}
