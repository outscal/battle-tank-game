using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyView enemyView;
    public TankScriptableObjectList tankList;
    public int Index;
    public EnemyModel enemyModel;

    void Start()
    {
        for(int i = 0;i<3;i++){
           CreateEnemy(i); 
        } 
    }
    
    private void CreateEnemy(int Index)
    {
        //int index = Random.Range(0, tankList.tanks.Length);
        TankScriptableObject tankScriptableObject = tankList.tanks[Index];
        //Debug.Log("Creating Tank with Type: " + tankScriptableObject.tankName);
         enemyModel  = new EnemyModel(tankScriptableObject);
        EnemyController enemyTank = new EnemyController(enemyModel, enemyView);
        
    }
}
