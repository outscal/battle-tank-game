using UnityEngine;

public class PlayerTankModel
{

    public BulletService bulletService;
    public float Speed { get; set; }
    public float RotationSpeed { get; set; }
    public Transform transform;
    public BulletScriptableObject bulletScriptableObject;
    public Transform bulletSpawnPoint;
    public Vector3 playerPosition;

    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject, Transform _transform, BulletScriptableObject _bulletScriptableObject,Transform _bulletSpawnPoint)
    {
        Speed = playerTankScriptableObject.Speed;
        RotationSpeed = playerTankScriptableObject.RotationSpeed;
        transform = _transform;
        bulletScriptableObject = _bulletScriptableObject;
        bulletSpawnPoint = _bulletSpawnPoint;

    }

    public void UpdatePlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }

    public void Move(float direction)
    {
        transform.position += transform.forward * direction * Speed * Time.deltaTime;
    }

    public void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * direction * RotationSpeed * Time.deltaTime);
    }

    public void Shoot()
    {
        BulletService.Instance.SpawnBullet(bulletScriptableObject.bulletType, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

}
