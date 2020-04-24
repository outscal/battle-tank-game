using UnityEngine;

[System.Serializable]
public class VFX
{
    public VFXName Name;
    public ParticleSystem vfx;
}



public enum VFXName
{
    None,
    TankExplosion,
    BulletExplosion,
}