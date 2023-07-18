
using Newtonsoft.Json.Bson;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    public Rigidbody Rb;


    private BulletController bulletController;
    
    public BulletModel BulletModel { get;private set; }


    public void SetBullerControler(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        BulletModel = bulletController.BulletModel;
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

    
}
