using UnityEngine;

public class GenericSinExampleClass : GenericSingleton<GenericSinExampleClass>
{
    protected override void Awake()
    {
        Debug.Log("Awake called from base class");
        base.Awake();
    }

    public void exampleFunc()
    {
        Debug.Log("Hello World");
    }
}
