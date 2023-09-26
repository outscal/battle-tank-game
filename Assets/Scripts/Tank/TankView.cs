using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TankView : MonoBehaviour
{
    private TankController tankController { get; set; }
    [SerializeField] private ShellService shellService;
    private void Start()
    {
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
