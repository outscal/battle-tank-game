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
}
