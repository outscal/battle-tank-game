using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public PlayerTankView tankView;
    [SerializeField]
    private TankScriptableObjectList tankScriptableObjectList;
    [SerializeField]
    private BulletView bulletPrefab;

    void Start()
    {
        PlayerTankModel model = new(tankScriptableObjectList.tankScriptableObjects[0],bulletPrefab);
        PlayerTankController controller = new(model, tankView);
    }

    
}
