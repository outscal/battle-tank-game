
using Newtonsoft.Json.Bson;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public Rigidbody rb;


    private BulletController bulletController;
    
    public BulletModel bulletModel { get;private set; }


    public void SetBullerControler(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Debug.Log(bulletController);
        bulletController.SetInitialVelocity();
        bulletModel = bulletController.bulletModel;
    }

    // Update is called once per frame
    void Update()
    {
        bulletController.MoveForword();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        bulletController.RemoveReferenceFromPlayerTankController();
    }
}
