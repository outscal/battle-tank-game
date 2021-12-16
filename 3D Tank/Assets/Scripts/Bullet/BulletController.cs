using System.Collections;
using UnityEngine;


    //Summary//
    //Script responsible for instantiation and destruction of bullet prefab with particle effects
    //-Summary//
public class BulletController : GenericSingleton<BulletController>
{
    [SerializeField] Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] ParticleSystem particles;
    public void Start()
    {
        rb.velocity = transform.forward * speed;          //setting the velocity of bullet prefab as soon as it is created
        particles = FindObjectOfType<ParticleSystem>();   //Finding the Particle System and setting it to variable
        StartCoroutine(Explode());                        //A Coroutine to destroy the bulet 
    }
    public BulletController(BulletModel model, BulletView bulletprefab)  //Method Instantiates the Bullet Prefab 
    {                                                                    //inheriting the data from its Bullet Model Script
        Model = model;
        BulletView = GameObject.Instantiate<BulletView>(bulletprefab,TankController.Instance.shootPoint);
    }

    private IEnumerator Explode()                  //Method to destroy the bullet prefab 
    {                                              //after playing the particle effect
        yield return new WaitForSeconds(1f);       //if it doesn't collide with anything
        particles.transform.parent = null;
        particles.Play();
        Destroy(gameObject); 
    }

    public void OnCollisionEnter(Collision other)  //Method to check whether bullet prefab 
    {                                              //collided with anything and if it does
        if (other != null)                         //destroy the bullet prefab after certain time
        {
          particles.transform.parent = null;
          particles.Play();
          Destroy(gameObject);
        }
    }

    public BulletModel Model { get; }
    public BulletView BulletView { get; }
}
