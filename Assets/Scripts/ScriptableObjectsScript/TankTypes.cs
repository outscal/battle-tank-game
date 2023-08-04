using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TankTypes", menuName = "Tanks/Tank Types")]
public class TankTypes : ScriptableObject
{
    public List<TankType> Types;
}
