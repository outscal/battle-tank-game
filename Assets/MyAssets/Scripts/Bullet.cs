using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter(Collision other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
        Destroy(gameObject, 0.5f);
    }
}