
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    public Rigidbody rb;

    public TankView tankView;

    public float speed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * Time.deltaTime * tankView.transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
