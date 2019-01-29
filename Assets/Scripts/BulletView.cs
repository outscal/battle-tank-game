using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour {

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move(Vector3 direction, float force, float destroyTime)
    {
        rb.AddForce(direction * force, ForceMode.Impulse);
        StartCoroutine(MoveObj(destroyTime));
    }

    IEnumerator MoveObj(float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }

}
