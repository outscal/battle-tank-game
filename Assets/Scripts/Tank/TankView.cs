
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(MeshCollider),typeof(Rigidbody))]
public class TankView : MonoBehaviour
{
    public TankController tankController;
    [SerializeField] private GameObject shooter;
    public Rigidbody tankRb;
    public Coroutine destroyThis;
    public Coroutine firing;
    public int checker = 0;
    public float distanceCovered = 0;

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
        tankController.UpdateTank();
        distanceCovered = tankController.tankModel.distanceCovered;
    }

    private void OnCollisionEnter(Collision collision)
    {
        tankController.UpdateCollisionControls();
        if(collision.gameObject.TryGetComponent<BulletView>(out BulletView bullet))
        {
            tankController.onBulletHit();
        }
    }

    public void startDestroyCoroutine(float seconds)
    {
        if(destroyThis!=null)
        {
            StopCoroutine(destroyThis);
            destroyThis = null;
        }
        destroyThis = StartCoroutine(destroy(seconds));
    }

    public void fireCoroutine(float seconds, bool _fire)
    {
        if (firing != null)
        {
            Debug.Log("firing coroutine stoppped");
            StopCoroutine(firing);
            firing = null;
        }
        firing = StartCoroutine(fireEnumerator(seconds, _fire));
    }
    private IEnumerator fireEnumerator(float seconds, bool fire)
    {
        while (fire)
        {
            tankController.Fire();
            yield return new WaitForSeconds(seconds);
        }
        StopCoroutine(firing);
    }
    public void StopFiring()
    {
        if (firing != null) StopCoroutine(firing);
    }

    private IEnumerator destroy(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tankController.destroyTankDatas();
        tankController = null;
        Destroy(gameObject);
    }
};
