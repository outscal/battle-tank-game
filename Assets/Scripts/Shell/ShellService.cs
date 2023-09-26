using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellService : SingletonGeneric<ShellService>
{
    [SerializeField] private ShellScriptableObjectList shellScriptableObjectList;
    public void SpawnShell(Transform spawn)
    {
        int randomNumber = (int)Random.Range(0f, shellScriptableObjectList.shells.Length - 1);
        ShellScriptableObject shellObject = shellScriptableObjectList.shells[randomNumber];
        Debug.Log("Created shell of type: " + shellObject.name);
        ShellModel model = new(shellObject);
        ShellController shellController = new(model, shellObject.shellView, spawn);
    }
}
