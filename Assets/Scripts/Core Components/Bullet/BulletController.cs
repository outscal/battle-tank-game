using UnityEngine;

public class BulletController
{
    public BulletModel BulletModel { get; }
    public BulletView BulletView { get; }

    public BulletController(BulletModel bulletModel, BulletView bulletViewPrefab)
    {
        BulletModel = bulletModel;
        BulletView = GameObject.Instantiate<BulletView>(bulletViewPrefab);

        BulletView.BulletController = this;
    }

    public void Update()
    {
        if (BulletView.Rigidbody.velocity.magnitude == 0)
        {
            BulletView.Destroy();
        }
    }

    public void SetDirection(Vector3 position, Quaternion rotation, Vector3 localScale)
    {
        BulletView.Position = position;
        BulletView.Rotation = rotation;
        BulletView.ApplyTranform = true;

        handleFireMovement();
    }

    void handleFireMovement()
    {
        float speed = BulletModel.Speed;

        Vector3 force = new Vector3(BulletView.Position.x * speed, BulletView.Position.y, BulletView.Position.x * speed);

        BulletView.Rigidbody.AddForce(force);
    }
}