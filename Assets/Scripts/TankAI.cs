using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;

    private GameObject player;
    private GameObject enemyTank;

    public Transform fireTransform;

    public GameObject shellInstance;

    public float fireForce;

    private GameObject shellGo;
    private GameObject enemyGo;


    public GameObject GetPlayer() { return player; }

    private void Awake()
    {
    }
    void Fire()
    {
        shellGo = PoolManager.Instantiate(shellInstance, fireTransform.position, fireTransform.rotation);
        Rigidbody shellRb = shellGo.GetComponent<Rigidbody>();
        shellRb.velocity = fireTransform.forward * fireForce;
    }

    public void StopFiring()
    {
        CancelInvoke("Fire");
    }
    public void StartFiring()
    {
        InvokeRepeating("Fire", 0.5f, 0.5f);
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.Instance.playerTank;
        //fireTransform = GetComponent<Transform>();
        PoolManager.SetNetPoolSize(shellInstance, 10);
        PoolManager.SetPoolSize(shellInstance, 5);
       
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
    }

    private void Update()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));

        if (EnemyController.Instance.isDead)
        {
            Die();
        }
    }
}
