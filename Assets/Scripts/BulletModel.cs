using System;

public class BulletModel
{
    private float damage = 10f;

    public float Damage
    {
        get { return damage; }
    }

    private float force = 10f;

    public float Force
    {
        get { return force; }
    }

    private float destroyTime = 2f;

    public float DestroyTime
    {
        get { return destroyTime; }
    }
}
