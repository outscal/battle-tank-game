using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public int hp;
    public float payrollSpeed;
    public int dmg;
    // Start is called before the first frame update


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            hp -= 25;
            Debug.Log("After hit - " + hp);
            if (isDead())
            {
                Destroy(gameObject);
                TankProvider.Instance.Boom(transform);
            }
        }
        else {
        }
    }

   

    private bool isDead()
    {
        if (hp <= 0) return true;
        return false;
    }
}

