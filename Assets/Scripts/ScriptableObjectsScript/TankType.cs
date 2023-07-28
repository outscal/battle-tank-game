using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TankType",menuName ="Tanks/Tank Type")]
public class TankType : ScriptableObject
{
    public string tankName;
    public int speed;
    public int health;
    public TankView tankview;
    public BulletType bulletType;

    
}

