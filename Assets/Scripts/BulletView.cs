using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour {

    private Rigidbody rb;

    [HideInInspector]
    public BulletController bulletController;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy.EnemyView>().DestroyEnemy();
        }

        DestroyBullet();
    }

    public void MoveBullet(Vector3 direction, float force, float destroyTime)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(destroyTime));
    }

    public void DestroyBullet()
    {
        bulletController.DestroyController();
        Destroy(gameObject);
    }

    IEnumerator DestroyBullet(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        DestroyBullet();
    }

}
