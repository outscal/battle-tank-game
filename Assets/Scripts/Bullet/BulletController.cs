using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    int damage = 25;
    BulletType type = BulletType.Slow;
    private void OnCollisionEnter(Collision collision){
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if(damageable != null){
            damageable.TakeDamage(type, 25);
        }
    }
}
