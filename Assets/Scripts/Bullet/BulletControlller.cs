using UnityEngine;
public class BulletController
{
    private BulletModel model;
    public void TakeDamage(float damage)
    {
        model.Damage -= damage;
    }

    public BulletController(BulletModel bulletModel)
    {
        model = bulletModel;
    }
}