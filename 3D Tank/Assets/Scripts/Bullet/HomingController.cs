using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HomingController : MonoBehaviour
{
    public Rigidbody rb;
    public AudioSource source;

    [SerializeField] 
    ParticleSystem particles;

    [SerializeField]
    private float speed = 15;

    [SerializeField]
    private float rotationSpeed = 1000;

    [SerializeField]
    private float focusDistance = 5;

    [SerializeField]
    private Transform target;

    private bool isLookingAtObject = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        particles = GetComponentInChildren<ParticleSystem>();
        source.Play();
    }

    private void LaunchHoming()
    {
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        StartCoroutine(HomingFollow());
    }

    IEnumerator HomingFollow()
    {
        LaunchHoming();

        yield return new WaitForSeconds(1f);

        Vector3 targetDirection = target.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

        if (Vector3.Distance(transform.position, target.position) < focusDistance)
        {
            isLookingAtObject = false;
        }

        if (isLookingAtObject)
        {
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    public void OnCollisionEnter(Collision other)  //Method to check whether bullet prefab 
    {                                              //collided with anything and if it does
        if (other != null)                         //destroy the bullet prefab after certain time
        {
            particles.transform.parent = null;
            particles.Play();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyController>().EnemyTakeDamage();
        }
        TankController.Instance.homingLaunched = false;
    }
}
