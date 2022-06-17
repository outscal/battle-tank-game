using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class BulletView : MonoBehaviour
{
    BulletController _bulletController;
    public Rigidbody _rb;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetController(BulletController bulletController)
    {
        _bulletController = bulletController;
    }
}
