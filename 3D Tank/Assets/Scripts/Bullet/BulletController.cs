using System;
using System.Collections;
using UnityEngine;


    //Summary//
    //Script responsible for instantiation and destruction of bullet prefab with particle effects
    //-Summary//
public class BulletController : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField] private Rigidbody rb;
    [SerializeField] public float speed;
    [SerializeField] ParticleSystem particles;
    [SerializeField] AudioSource source;
    #endregion
    public void Start()
    {
        rb.velocity = transform.forward * speed;
        source.Play();                                    //setting the velocity of bullet prefab as soon as it is created
        particles = FindObjectOfType<ParticleSystem>();   //Finding the Particle System and setting it to variable
        StartCoroutine(Explode());                        //A Coroutine to destroy the bullet 
    }
    public BulletController(BulletModel model, BulletView bulletprefab, Transform shootpos)  //Method Instantiates the Bullet Prefab 
    {                                                                           //inheriting the data from its Bullet Model Script
        Model = model;
        BulletView = GameObject.Instantiate<BulletView>(bulletprefab,shootpos);
        Shootpos = shootpos;
    }

    private IEnumerator Explode()                  //Method to destroy the bullet prefab 
    {                                              //after playing the particle effect
        yield return new WaitForSeconds(1f);       //if it doesn't collide with anything
        particles.transform.parent = null;
        particles.Play();
        Destroy(gameObject); 
    }

    private void Update()
    {
        TankController.Instance?.BulletCount();
    }

    public void OnCollisionEnter(Collision other)  //Method to check whether bullet prefab 
    {                                              //collided with anything and if it does
        if (other != null)                         //destroy the bullet prefab after certain time
        {
            if (other.gameObject.CompareTag("Player"))
            {
                TankController.Instance.TakeDamage();
            }
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<EnemyController>().EnemyTakeDamage();
            }
          
          particles.transform.parent = null;
          particles.Play();
          Destroy(gameObject);
        }
    }
    public BulletModel Model { get; }
    public BulletView BulletView { get; }
    public Transform Shootpos { get; }
}
