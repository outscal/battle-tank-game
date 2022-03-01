using System;
using Bullet;
using Tank;
using UnityEngine;

public abstract class TankView : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    protected TankController _tankController;

    public TankController TankController => _tankController;
    public void SetTankController(TankController tankController) => _tankController = tankController;
    public Transform ShootingPoint => _shootingPoint;

    protected virtual void OnCollisionEnter(Collision other)
    {
        _tankController.HitBy(other);
    }
}
