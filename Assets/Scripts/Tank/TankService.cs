using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankService : MonoSingletonGeneric<TankService>
{
    public TankView tankView;
    [SerializeField]
    private TankScriptableObjectList tankScriptableObjectList;
    [SerializeField]
    private GameObject bulletPrefab;

    void Start()
    {
        TankModel model = new(tankScriptableObjectList.tankScriptableObjects[0],bulletPrefab);
        TankController controller = new(model, tankView);
    }

    
}
