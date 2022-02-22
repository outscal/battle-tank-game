using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public int Speed { get; private set; }
    public float Damage { get; private set; }
    private Control control;

    public Model(Bulletscript bulletScript)
    {
        Speed = bulletScript.Speed;
        Damage = bulletScript.Damage;


    }
    public void setControl(Control control)
    {
        this.control = control;
    }

}
