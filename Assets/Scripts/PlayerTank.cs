using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : GenericSingleton<PlayerTank>
{
    private void Awake() //simple implementation
    {
        Debug.Log("called singleton from child");
        GenericSingleton<PlayerTank>.Instance.MakeSingleton();
    }
}
