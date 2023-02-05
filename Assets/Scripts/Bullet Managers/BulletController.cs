using UnityEngine;

public class BulletController
{
    private BulletModel bulletModel;
    private BulletView bulletView;
    private Rigidbody rb;
    public MeshRenderer bulletMesh;
    private Transform Explosion;
    public BulletController(BulletModel _bulletmodel, BulletView _bulletview, Transform bulletTransform)
    {
        bulletModel = _bulletmodel;
        bulletView =  GameObject.Instantiate<BulletView>(_bulletview,bulletTransform);
        rb = bulletView.GetComponent<Rigidbody>();
        bulletMesh = bulletView.GetComponent<MeshRenderer>();
        Explosion = bulletView.gameObject.transform.GetChild(0).transform;
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
    }
    public void Explode()
    {
        bulletMesh.enabled = !bulletMesh.enabled;
        bulletView.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }
    private void OnEnable() {
        var launch = bulletView.transform.forward * bulletModel.bulletSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + launch);
    }
    public BulletModel GetBulletModel()
    {
        return bulletModel;
    }
}
