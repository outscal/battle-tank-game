using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This Class is Attached to a Tank GameObject and is responsible for rendering and UI related work.
/// </summary>
public class TankView : MonoBehaviour,IDamagable
{
    public GameObject Turret;
    public Transform BulletSpawner;
    private TankController tankController;

    //public Slider sliderHealth;
    
    public Image healthBar;
    //public Color fullHealthColor = Color.green;
    //public Color zeroHealthColor = Color.red;

    //public Button FireButton;


    public Rigidbody shellPrefab;
    //public Transform fireTransform;
    public Slider aimSlider;

    public bool fired;
    internal bool tankDead;

    private void FixedUpdate()
    {
        tankController.HandleLeftJoyStickInput(GetComponent<Rigidbody>());
        tankController.HandleRightJoyStickInput(Turret.transform);
        tankController.SetHealthUI();
    }

    private void Update()
    {
        
    }
    // Sets a reference to the corresponding TankController Script.
    public void SetTankControllerReference(TankController controller)
    {
        tankController = controller;
    }
    

    void IDamagable.TakeDamage(float damage)
    {
        Debug.Log("Player Taking Damage" + damage);
        //tankController.TakeDamage(damage);
    }
    private void OnEnable()
    {
        tankController.OnEnableFunction();
        //tankController.SetHealthUI();
    }

}