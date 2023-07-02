using UnityEngine;

public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    [SerializeField] Rigidbody rb;
    void Start()
    {
        bulletController.Shoot();
    }
    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    void OnCollisionEnter(Collision col)
    {
        bulletController.BulletCollision(col.contacts[0].point);
        IDamageable target = col.gameObject.GetComponent<IDamageable>();
        if (target != null)
        {
            target.TakeDamage(bulletController.GetBulletDamage());
        }
    }
}
