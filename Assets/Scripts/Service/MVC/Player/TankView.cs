using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankView : MonoBehaviour, IDamagable
{
    private TankController tankController;
    public Transform bulletSpawner;
    private float movement;
    private float rotation;
    public List<Material> colors;
    [SerializeField] private MeshRenderer Chasis;
    [SerializeField] private MeshRenderer Turret;
    [SerializeField] private Rigidbody rb;
    private Joystick joystick;

    public void SetJoyStick(Joystick joyStick)
    {
        joystick = joyStick;
    }
    private void Start() {
        Chasis.material = tankController.GetTankModel().color;
        Turret.material = tankController.GetTankModel().color;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Movement();

        if(movement != 0)
        {
            tankController.Move(movement, tankController.GetTankModel().Speed);
        }
        if(rotation != 0)
        {
            tankController.Turn(rotation, tankController.GetTankModel().TurnSpeed);
        }
    }
    
    private void Movement()
    {
        movement = joystick.Vertical;
        rotation = joystick.Horizontal;
    }
    
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void SetTankController(TankController tankcontroller)
    {
        tankController = tankcontroller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public void GetDamage(float damage, TypeDamagable type)
    {
       tankController.GetDamage(damage, type);
    }
}