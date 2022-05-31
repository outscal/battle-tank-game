using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Rigidbody rb;

    public void SetEnemyController(EnemyController _enemycontroller)
    {
      enemyController = _enemycontroller;
    }  

   public Rigidbody GetRigidbody()
   {
     return rb;
   }
}


