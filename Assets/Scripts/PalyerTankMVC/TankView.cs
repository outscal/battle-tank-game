using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
   [SerializeField]private Rigidbody rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        CameraFollow();
    }

    private void CameraFollow()
    {
        GameObject gameObject1 = GameObject.Find("Main Camera");
        GameObject cam = gameObject1;
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 20f, -10);
        cam.transform.rotation *= Quaternion.Euler(50f, 0f, 0f);

    }

    private void FixedUpdate()
    {
       tankController.TankMove();
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

   
}
