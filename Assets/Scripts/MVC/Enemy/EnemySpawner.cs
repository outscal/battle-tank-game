using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyView enemyView;
    public TankScriptableObjectList enemyList;
    public int enemyTypeIndex;

    void Start()
    {
        // for(int i = 0;i<3;i++){
        //    CreateEnemy(i); 
        // } 
    }
}
