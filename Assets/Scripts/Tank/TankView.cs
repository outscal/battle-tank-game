
using System;
using UnityEngine;

[RequireComponent(typeof(MeshCollider),typeof(Rigidbody))]
public class TankView : MonoBehaviour
{
    public TankController tankController;
    [SerializeField] private GameObject shooter;
    public Rigidbody tankRb;

    private void Awake()
    {
        tankRb= GetComponent<Rigidbody>();
    }

    private void Start()
    {
        gameObject.GetComponent<MeshCollider>().convex= true;
        tankController.tankModel.shootertransform = shooter.transform;
    }
    public void getTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    void changeMaterial(Material _material)
    {
        gameObject.GetComponent<MeshRenderer>().material = _material;
    }

    private void Update()
    {
        tankController.UpdateAutoControls();
    }

    private void OnCollisionEnter(Collision collision)
    {
        tankController.UpdateCollisionControls();
        if(collision.gameObject.TryGetComponent<BulletView>(out BulletView bullet))
        {
            tankController.onBulletHit();
        }
    }
};
