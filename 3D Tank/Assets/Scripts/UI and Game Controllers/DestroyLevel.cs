using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevel : GenericSingleton<DestroyLevel>
{

    public GameObject[] objects;
    public List<GameObject> enemy;

    private void Start()
    {
    }

    public void DestroyAll()
    {
        //Destroy(EnemyController.Instance.gameObject, 2f);
        for (int i = 0; i < objects.Length; i++)
          {
            Debug.Log("Entered the loop");
            Destroy(objects[i],i);
          }
    }
}
