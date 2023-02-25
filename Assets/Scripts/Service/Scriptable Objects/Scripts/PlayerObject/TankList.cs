using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tank Object List", menuName = "Objects/New Tank Object List")]
public class TankList : ScriptableObject
{
    public TankObject[] tanks;
}