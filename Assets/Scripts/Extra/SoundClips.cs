using UnityEngine;

[System.Serializable]
public class SoundClips
{
    public ClipName Name;
    public AudioClip Clip;
}

public enum ClipName
{
    None,
    TankExplosion,
    BulletExplosion,
    ShotFiring,
}
