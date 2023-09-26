using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellModel
{
    public float shell_Speed { get; private set; }
    public float shell_Damage { get; private set; }
    public ShellTypes shell_Type { get; private set; }

    public ShellModel(ShellScriptableObject shellScriptableObject)
    {
        shell_Speed = shellScriptableObject.speed;
        shell_Damage = shellScriptableObject.damage;
        shell_Type = shellScriptableObject.type;
    }

}
