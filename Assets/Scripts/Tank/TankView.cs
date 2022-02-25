using System;
using Bullet;
using Tank;
using UnityEngine;

public class TankView : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    private TankController _tankController;

    public void SetTankController(TankController tankController) => _tankController = tankController;
    public Transform ShootingPoint => _shootingPoint;

    private void Update()
    {
        _tankController.HandleAttacks();
    }

    private void FixedUpdate()
    {
        _tankController.Move();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<BulletView>())
        {
            Debug.Log("hit by bullet!");
            _tankController.TakeDamage(other.gameObject.GetComponent<BulletView>().BulletController.BulletModel.Damage);
        }
    }
}
