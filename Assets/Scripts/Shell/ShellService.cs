using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellService : SingletonGeneric<ShellService>
{
    [SerializeField] private ShellScriptableObjectList shellScriptableObjectList;
    private void Start()
    {
        //CreateShell();
    }

    /*private ShellController CreateShell()
    {
        
    }*/
}
