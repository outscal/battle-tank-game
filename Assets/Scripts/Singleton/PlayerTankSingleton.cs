using UnityEngine;

class PlayerTankSingleton : GenericSingleton<PlayerTankSingleton>
{
    protected override void Awake()
    {
        base.Awake();
    }
}