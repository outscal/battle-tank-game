using UnityEngine;

public class PlayerTankModel
{
    public BulletService bulletService;
    public float Speed { get; set; }
    public float Health { get; set; }
    public float RotationSpeed { get; set; }
    public Transform transform;
    public BulletScriptableObject bulletScriptableObject;
    public Vector3 playerPosition;
    public float bulletDamage;
    public BulletType bulletType;



    public PlayerTankModel(PlayerTankScriptableObject playerTankScriptableObject, Transform _transform)
    {
        Speed = playerTankScriptableObject.Speed;
        RotationSpeed = playerTankScriptableObject.RotationSpeed;
        transform = _transform;
        Health = playerTankScriptableObject.Health;
    }
    public void UpdatePlayerPosition(Vector3 position)
    {
        playerPosition = position;
    }


}
