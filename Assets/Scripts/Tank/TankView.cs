using UnityEngine;

public class TankView : MonoBehaviour, IDamagable
{
    public float GetHealth { get { return TankController.GetTankModel().Health; } }
    public float GetMaxHealth { get { return TankController.GetTankModel().MaxHealth; } }
    public float GetDamage { get { return TankController.GetTankModel().Damage; } }
    private TankController TankController { get; set; }

    //--------------------FUNCTIONS-------------------------
    //PRIVATE FUNCTIONS
    private void Start()
    {
        Debug.Log("Tank view created!");
        AssetManager.Instance.SetTankView(this);
        TankController.Initialize();
    }

    private void Update()
    {
        TankController.Simulate();
    }

    private void FixedUpdate()
    {
        if (TankController != null)
        {
            if (TankController.tank_IsTurning) { TankController.Turn(); }
            if (TankController.tank_IsMoving) { TankController.Move(); }
        }
        else
        {
            return;
        }
    }

    private void OnEnable()
    {
        GetRigidBody().isKinematic = false;
    }

    private void OnDisable()
    {
        GetRigidBody().isKinematic = true;
    }

    //PUBLIC FUNCTIONS
    public Rigidbody GetRigidBody()
    {
        return GetComponent<Rigidbody>();
    }

    public void SetTankController(TankController _tankController)
    {
        TankController = _tankController;
    }

    public void DestroyTank()
    {
        TankController.DestroyTank();
    }

    public void Shoot()
    {
        TankController.ShootShell();
    }

    public bool TakeDamage(float damage)
    {
        return TankController.TakeDamage(damage);
    }

    public bool GiveDamage(IDamagable damagable)
    {
        return TankController.GiveDamage(damagable);
    }
}
