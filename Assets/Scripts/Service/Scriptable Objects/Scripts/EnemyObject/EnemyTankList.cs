using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Tank Object List", menuName = "Objects/New Enemy Tank Object List")]
public class EnemyTankList : ScriptableObject
{
    public EnemyTankObject[] EnemyTanks;
}