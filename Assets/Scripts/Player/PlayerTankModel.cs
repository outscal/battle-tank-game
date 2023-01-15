using UnityEngine;

public class PlayerTankModel
{

    public BulletService bulletService;
    public PlayerTankType PlayerTankType { get; set; }
    public float Speed { get; set; }
    public float RotationSpeed { get; set; }
    public Transform transform;
    public BulletScriptableObject bulletScriptableObject;
    public Transform bulletSpawnPoint;

    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject, Transform _transform, BulletService _bulletService, BulletScriptableObject _bulletScriptableObject)
    {
        PlayerTankType = playerTankScriptableObject.pTankType;
        Speed = playerTankScriptableObject.Speed;
        RotationSpeed = playerTankScriptableObject.RotationSpeed;
        transform = _transform;
        bulletService = _bulletService;
        bulletScriptableObject = _bulletScriptableObject;
    }

    public void Move(float direction)
    {
        transform.position += transform.forward * direction * Speed * Time.deltaTime;
    }

    public void Rotate(float direction)
    {
        transform.Rotate(Vector3.up * direction * RotationSpeed * Time.deltaTime);
    }

    public void Shoot(BulletScriptableObject bulletScriptableObject)
    {
        BulletModel bulletModel = new BulletModel(bulletScriptableObject);
        BulletView bulletView = new BulletView();
        bulletView.prefab = bulletScriptableObject.prefab;
        BulletController bulletController = new BulletController(bulletModel);
        bulletView.Fire(bulletSpawnPoint.position, bulletSpawnPoint.rotation, bulletModel.Speed);
    }
}
