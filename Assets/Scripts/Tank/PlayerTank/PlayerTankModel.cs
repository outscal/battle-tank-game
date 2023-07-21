
using System;
using UnityEngine;
[Serializable]
public class PlayerTankModel 
{
    public float MovementSpeed { get; private set; }
    public float RotationSpeed { get; private set; }

    public float Health;

    public PlayerTankModel(PlayerTankScriptableObject tankScriptableObject)
    {
        MovementSpeed = tankScriptableObject.MovementSpeed;
        RotationSpeed = tankScriptableObject.RotationSpeed;
        Health = tankScriptableObject.Health;
    }

}
