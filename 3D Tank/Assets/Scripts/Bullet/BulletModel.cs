using UnityEngine;


    //Summary//
    //Script contains the data for Bullet Model
    //-Summary//
public class BulletModel
{
    public BulletModel(BulletStats stats)
    {
        Damage = stats.damage;    
    }

    public int Damage { get; set; } 
}
