using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBulletModel
{
    public TankBulletModel(TankBulletScriptableObject tankBulletScriptableObject)
    {
        TankBUlletType = tankBulletScriptableObject.TankBUlletType;
      //BulletSpawnPosition = tankBulletScriptableObject.BulletSpawnPosition;
        BulletPrefab = tankBulletScriptableObject.BulletPrefab;
        BulletSpeed = tankBulletScriptableObject.BulletSpeed;


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public TankBUlletType TankBUlletType { get; }

    public Transform BulletSpawnPosition { get; }
    public GameObject BulletPrefab { get; }
    public float BulletSpeed { get; }
}
