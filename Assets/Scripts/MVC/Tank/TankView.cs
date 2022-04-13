using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{
    public GameObject Turret;
    public GameObject BulletEmitter;
    public Slider healthSlider;
    public Image healthFillImage;
    public Color maxHealthColour = Color.green;
    public Color minHealthColour = Color.red;
    public GameObject explosionPrefab;
    public bool isTankLive = false;
    public AudioSource explosionSound;
    public ParticleSystem explosionParticles;
    [HideInInspector]
    public TankController tankController;

    private void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }
    void Start()
    {
        Debug.Log("TankView Createtd");

    }

    public void SetTankControllerReference(TankController controller)
    {
        tankController = controller;
    }

    public void DestroyTank()
    {
        Destroy(gameObject);
    }

    public void DestroyGround(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}