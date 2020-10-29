using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyTank enemy;
    [SerializeField]
    private EnemyTank bossEnemy;
    [SerializeField]
    private GameObject tankExplosion;
    private Rigidbody rgbd;

    private int hp;
    private float payrollSpeed;
    private int dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            hp = enemy.getHP();
            payrollSpeed = enemy.getSpd();
            dmg = enemy.getDmg();
        }
        else
        {
            hp = bossEnemy.getHP();
            payrollSpeed = bossEnemy.getSpd();
            dmg = bossEnemy.getDmg();
            rgbd = GetComponent<Rigidbody>();
            rgbd.mass = 50;
        }
    }
        // Update is called once per frame
        void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9) {
            hp -= 25;
            if (isDead()) {
                Boom();
                Destroy(gameObject);
            } 
        }
    }

    private void Boom()
    {
        GameObject explosion = Instantiate(tankExplosion, transform.position, transform.rotation);
        explosion.transform.localScale *= 3f;
        Destroy(explosion, 2f);
    }

    private bool isDead()
    {
        if (hp <= 0) return true;
        return false;
    }
}

