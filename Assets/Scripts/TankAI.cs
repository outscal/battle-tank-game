using UnityEngine;

public class TankAI : MonoBehaviour
{
    Animator anim;

    private GameObject player;
    private GameObject enemy;

    public Transform fireTransform;

    public GameObject GetPlayer() { return player; }

    void Fire()
    {
        GameObject shell = Instantiate(GameManager.Instance.shells, fireTransform.position, transform.rotation);
        Rigidbody shellBody = shell.GetComponent<Rigidbody>();
        shellBody.AddForce(transform.forward * 1500);
    }

    public void StopFiring() { CancelInvoke("Fire"); }
    public void StartFiring() { InvokeRepeating("Fire", 0.5f, 0.5f); }

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameManager.Instance.playerTank;
        enemy = Spawner.Instance.enemyTank;
        fireTransform = GetComponent<Transform>();
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
