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


    public void MoveBullet(Vector3 direction, float force, float destroyTime)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
        StartCoroutine(DestroyBullet(destroyTime));
    }

    IEnumerator DestroyBullet(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        bulletController.DestroyController();
        Destroy(gameObject);
    }

}
