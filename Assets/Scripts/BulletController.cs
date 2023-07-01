
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
        rb.velocity = speed *  tankView.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed * Time.deltaTime * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
