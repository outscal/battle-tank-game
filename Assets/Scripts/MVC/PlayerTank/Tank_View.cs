using System.Collections;
using UnityEngine;

public class Tank_View : MonoBehaviour
{
    private Tank_Ctrl tankController;
    private float movement;
    private float rotation;
    public Transform bulletspawnPos;
    public float health;

    public TankType tankType;
    public Rigidbody rb;

    int firedBulletCount = 0;

    [SerializeField]
    private ServicePoolBullet servicePoolBullet;


    void Start()
    {
        GameObject cam = GameObject.Find("Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 3f, -4f);
        health = tankController.TankHealth();
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
                tankBulletController.SetVisibilityStatus(true);
                StartCoroutine(ReturnBulletWaitTime(tankBulletController));
                firedBulletCount += 1;
                TankBulletService.Instance?.bulletFiredbyPlayer(firedBulletCount);
            }
        }
      
    }

    IEnumerator ReturnBulletWaitTime(TankBulletController tankBulletController)
    {
        yield return new WaitForSeconds(5f);
        tankBulletController.SetVisibilityStatus(false);
        TankBulletService.Instance.GetBulletPool().ReturnItem(tankBulletController);
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

    public Tank_Ctrl GetTankController()
    {
        return tankController;
    }
}
 