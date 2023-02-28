using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class TankView : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }
}
