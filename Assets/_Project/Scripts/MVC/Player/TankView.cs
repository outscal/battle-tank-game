using UnityEngine;

public class TankView : MonoBehaviour {

    private TankController tankController;

    private float movement;
    private float rotation;

    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        Camera cam = FindObjectOfType<Camera>();
        cam.transform.SetParent(transform);
    }

    private void Update()
    {
        Movement();

        if (movement != 0)
            tankController.Move(movement);

        if (rotation != 0)
            tankController.Rotate(rotation);
    }

    private void Movement()
    {
        movement = Input.GetAxisRaw("VerticalUI");
        rotation = Input.GetAxisRaw("HorizontalUI");
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public Rigidbody GetRigiBody()
    {
        return rb;
    }
}
