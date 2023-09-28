using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TankView : MonoBehaviour
{
    private TankController tankController { get; set; }
    [SerializeField] private ShellService shellService;
    [SerializeField] private ExplodeLevel explode;

    //--------------------FUNCTIONS-------------------------
    //PRIVATE FUNCTIONS
    private void Start()
    {
        explode = GameObject.FindGameObjectWithTag("Explode").GetComponent<ExplodeLevel>();
        Debug.Log("Tank view created!");
        tankController.Initialize();

    }

    private void Update()
    {
        tankController.Simulate();
    }

    private void FixedUpdate()
    {
        if (tankController != null)
        {
            if (tankController.tank_IsTurning) { tankController.Turn(); }
            else if (tankController.tank_IsMoving) { tankController.Move(); }
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<EnemyView>())
        {
            StartCoroutine(explode.DestroyLevel());
        }
    }


    //PUBLIC FUNCTIONS
    public Rigidbody GetRigidBody()
    {
        return GetComponent<Rigidbody>();
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public ShellService GetShellService()
    {
        return shellService;
    }

    public void Shoot()
    {
        tankController.ShootShell(shellService);
    }
}
