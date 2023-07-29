using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Type", menuName = "Bullets/bullet type")] 
public class BulletType : ScriptableObject
{
    public int speed;
    public BulletView bulletView;
}