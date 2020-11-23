using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour{

    [Serializable]
    public class Pool{
         public string name;
         public int size; 
         public GameObject prefab;
    }

    public Pool[] PoolList;
    private Dictionary<string,Queue<GameObject>> poolDictionary = new  Dictionary<string,Queue<GameObject>>();
    private Queue<GameObject> gameObjectQueue = new Queue<GameObject>();

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Start() {

        foreach(var item in PoolList){
            for(int i=0;i<item.size;i++){
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                gameObjectQueue.Enqueue(obj);
            }
            poolDictionary.Add(item.name,gameObjectQueue);
        }
                
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````

    internal void spawner(){
        Debug.Log("InSpawner");
        GameObject obj = poolDictionary["EnemyTank"].Dequeue();         //Pop a tank from pool Queue

        float xLocation = UnityEngine.Random.Range(-30,36);             //calculating random Position
        float zLocation = UnityEngine.Random.Range(-41,40);
        Vector3 location = new Vector3(xLocation,0,zLocation);          
        obj.transform.position = location;                              //Setting A random Position

        obj.SetActive(true);                                            //Activating the obj that we poped
        Debug.Log("check 123");
        poolDictionary["EnemyTank"].Enqueue(obj);                       //pushing back the obj refrence into the same queue
        
        //return obj;                                                     //returning the tank that we poped
    }

    
}
