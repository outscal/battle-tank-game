using System.Collections;
using UnityEngine;

public class Tank_View : MonoBehaviour
{
    private Tank_Ctrl tankController;
    private float movement;
    private float rotation;
    public Transform bulletspawnPos;
    TankBulletController tankBulletController;
    public float health;

    public TankType tankType;
    public Rigidbody rb;

    int firedBulletCount = 0;


    private ServicePoolBullet servicePoolBullet;
    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
        health = tankController.TankHealth();
        servicePoolBullet = GetComponent<ServicePoolBullet>();
        tankBulletController = GetComponent<TankBulletController>();
    }

    private void Update()
    {
       
        Movement();
        if (tankController.TankHealth() > 0)
        {
            if (movement != 0)
            {
                tankController.Move(movement, tankController.GetTankModel().Speed);
            }

            if (rotation != 0)
            {
                tankController.Roatate(rotation, tankController.GetTankModel().RotationSpeed);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                TankBulletController tankBulletController = TankBulletService.Instance.CreateNewBullet(bulletspawnPos);
                servicePoolBullet.ReturnItem(tankBulletController);

               // TankBulletService.Instance.CreateNewBullet(bulletspawnPos);
                firedBulletCount += 1;
                TankBulletService.Instance?.bulletFiredbyPlayer(firedBulletCount);
            }
        }
        //else
        //{
        //    StartCoroutine(DestroyEnimies());
        //}
      
    }

    public void SetTankBUlletController(TankBulletController _tankBulletController)
    {
        tankBulletController = _tankBulletController;
    }

    private void Movement()
    {
        movement = Input.GetAxis("Horizontal");
        rotation = Input.GetAxis("Vertical");
    }

    public void SetTankController(Tank_Ctrl _tankCtrl)
    {
        tankController = _tankCtrl;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<TankBulletView>())
        {
            tankController.tankmodel.Health = tankController.tankmodel.Health - collision.gameObject.GetComponent<TankBulletView>().GetDamage();
            Debug.Log("health: " + tankController.tankmodel.Health);
        } 
    }


    // will comeback and find best approach for this

    IEnumerator DestroyEnimies()
    {
        if (tankController.TankHealth() < 0)
        {
            Destroy(GameObject.FindWithTag("Enemy"));
            yield return new WaitForSeconds(1f);
            StartCoroutine(DestroyEnvironment());
        }
    }

    IEnumerator DestroyEnvironment()
    {
        Destroy(GameObject.FindWithTag("Ground"));
        yield return null;
    }
}
 