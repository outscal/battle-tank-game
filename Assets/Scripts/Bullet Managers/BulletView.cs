using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    public Rigidbody rbullet;
    public MeshRenderer bulletMesh;
    private void Awake() {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    private void OnTriggerEnter(Collider other) {
        bulletController.Explode();
    }
}
