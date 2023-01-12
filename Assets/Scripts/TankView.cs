using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;


    public Rigidbody _rigidbody;


    private float movement;
    private float rotate;



    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameObject camera = GameObject.Find("Main Camera");
        camera.transform.SetParent(transform);
        camera.transform.position = new Vector3(0, 28f, -30f);
    }

    void Update()
    {
        Movement();
        if (movement != 0)
            tankController.Move(movement, tankController.GetTankModel().movementSpeed);

        if (rotate != 0)
            tankController.Rotate(rotate, tankController.GetTankModel().rotationSpeed);
    }

    private void Movement()
    {

        movement = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");


    }

    public Rigidbody GetRigidbody()
    {
        return _rigidbody;
    }

}
