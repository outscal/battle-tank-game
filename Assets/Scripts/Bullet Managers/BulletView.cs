using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public LayerMask TankMask;
    public Rigidbody rbullet;
    //public MeshRenderer bulletMesh;
    private void Awake() {
        Debug.Log("Awake");
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    private void OnCollisionEnter(Collision other) {
        bulletController.bulletContact();
        Destroy(gameObject);
        Destroy( bulletController.Explosion.gameObject, 2f);
    }
}
