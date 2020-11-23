using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour,Idamagable
{ 
    public int hp;
    public float payrollSpeed;
    public int dmg;
    // Start is called before the first frame update

    public void takeDamage() {
        hp -= 25;
        Debug.Log("After hit - " + hp);
        if (isDead())
        {
            Destroy(gameObject);
            TankProvider.Instance.Boom(transform);
        }
    }
         
    
   

    private bool isDead()
    {
        if (hp <= 0) return true;
        return false;
    }
}

