using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] private ParticleSystem Explosion;
    private BulletController bulletController;
    public LayerMask TankMask;
    public Rigidbody rbullet;
    //public MeshRenderer bulletMesh;
    private void Awake() {
        Debug.Log("Awake Bullet");
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    private void OnCollisionEnter(Collision other) {
        bulletController.bulletContact();
        Explosion.gameObject.transform.SetParent(null);
        Explosion.Play();
        Destroy(Explosion.gameObject, 2f);
        Destroy(gameObject);
    }
}
