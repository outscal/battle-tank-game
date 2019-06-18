using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputComponentList", menuName = "ScriptableObj/InputComponentList",order = 3)]
public class InputComponentScriptableList : ScriptableObject 
{
    public List<InputComponentScriptable> inputComponentScriptables;
	
}
