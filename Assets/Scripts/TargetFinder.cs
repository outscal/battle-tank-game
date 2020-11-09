using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFinder : MonoBehaviour
{
    Animator anim;
    private GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("EnemyController");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        EnemyController point = enemy.GetComponentInChildren<EnemyController>();
        if (point != null)
        {
            anim.SetBool("enemyFound", true);
            var dir = point.transform.position - transform.position;
            var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        else
        {
            anim.SetBool("enemyFound", false);
        }
    }
}
