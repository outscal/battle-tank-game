using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellService : SingletonGeneric<ShellService>
{
    [SerializeField] private ShellScriptableObjectList shellScriptableObjectList;

    private void Start()
    {
        AssetManager.Instance.SetShellService(this);
    }

    public void SpawnShell(Transform spawn, LayerMask shellLayer, float damage = 0f)
    {
        int randomNumber = (int)Random.Range(0f, shellScriptableObjectList.shells.Length);
        ShellScriptableObject shellObject = shellScriptableObjectList.shells[randomNumber];
        Debug.Log("Created shell of type: " + shellObject.name);
        ShellModel model = new(shellObject, damage);
        new ShellController(model, shellObject.shellView, shellLayer, spawn);
    }
}
