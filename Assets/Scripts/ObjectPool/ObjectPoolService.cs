using System.Collections;
using UnityEngine;

namespace Outscal.BattleTank
{
    public class ObjectPoolService : MonoGenericSingletone<ObjectPoolService>
    {
        [SerializeField] private BulletView bulletView;
        [SerializeField] private int amtToPool;


        
    }
}