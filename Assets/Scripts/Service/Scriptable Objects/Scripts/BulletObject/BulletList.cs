using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Object List", menuName = "Objects/New Bullet Object List")]
public class BulletList : ScriptableObject
{
    public BulletObject[] bullets;
}