using Singleton;
using UnityEngine;

public class TankController : MonoSingletonGeneric<TankController>
{
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Creating tank");
    }

    public void CallTest()
    {
        Debug.Log(this.gameObject.name);
    }
}
