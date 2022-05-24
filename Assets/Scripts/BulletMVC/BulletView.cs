using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class is attached to the Bullet Game Object in the game.
/// </summary>
public class BulletView : MonoBehaviour
{
    BulletController bulletController;
    public ParticleSystem BExplode;
    [SerializeField]private AudioSource BEAudio;

    private void Start()
    {
        Destroy(gameObject, bulletController.BulletModel.maxLifeTIme);
    }

    public void Initialize(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }


    private void OnTriggerEnter(Collider collision)
    {

        bulletController.InflictDamage(collision.gameObject);

        BExplode.transform.parent = null;

        BExplode.Play();
        BEAudio.Play(); 
        Destroy(BExplode.gameObject, BExplode.main.duration);
        Destroy(gameObject);
        

        //BExplode.Play();
        Debug.Log("destroy bullet");


    }
}
