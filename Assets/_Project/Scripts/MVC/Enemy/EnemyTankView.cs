using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(Image))]

public class EnemyTankView : MonoBehaviour, IDamagable
{
    public TankType tankType;
    public EnemyTankController EnemyTankController;

    public Rigidbody rb;

    public Slider sliderHealth;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color zeroHealthColor = Color.red;

    public Rigidbody shellPrefab;
    public Transform fireTransform;
    public Slider aimSlider;



    internal bool fire1 = false;
    internal bool fire0 = false;
    internal bool fire3 = false;

    public bool fired;
    internal bool enemyTankDead;
    private void Awake()
    {
        InitializeComponenets();
    }
    private void Start()
    {
        Debug.Log("EnemyTank View Created");
        EnemyTankController.StartFunction();
    }
    private void Update()
    {
        EnemyTankController.FireControl();
    }
    private void InitializeComponenets()
    {
        rb = GetComponent<Rigidbody>();
    }

    void IDamagable.TakeDamage(float damage)
    {
        Debug.Log("Tank Taking Damage" + damage);
        EnemyTankController.ApplyDamage(damage);
    }
}
