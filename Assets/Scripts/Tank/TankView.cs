using System;
using Bullet;
using Tank;
using UnityEngine;

public abstract class TankView : MonoBehaviour, IDamageable
{
    [SerializeField] private Transform _shootingPoint;
    protected TankController _tankController;

    public TankController TankController => _tankController;
    public void SetTankController(TankController tankController) => _tankController = tankController;
    public Transform ShootingPoint => _shootingPoint;

    public void DamageReceived(float amount)
    {
        _tankController.TakeDamage(amount);
    }
}
