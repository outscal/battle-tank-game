using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody rgbd;
    [SerializeField]
    private GameObject shellExplosion;
    // Start is called before the first frame update
    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rgbd.velocity = new Vector3(transform.forward.x*25f,transform.forward.y*2f,transform.forward.z*25f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Idamagable damagable = collision.gameObject.GetComponent<Idamagable>();
        if (damagable != null) {
            damagable.takeDamage();        
        }
        var explosion = Instantiate(shellExplosion, transform.position, transform.rotation);
        Destroy(explosion, 1f);
        Destroy(gameObject);
    }
}
