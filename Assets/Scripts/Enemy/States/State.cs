using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{

    public int MP = 1;
    public static float attackCD = 1f;
    public float nextAttack = 0f;
    public virtual void EnterState()
    {
    }
    public virtual void ExitState()
    {
    }

}
