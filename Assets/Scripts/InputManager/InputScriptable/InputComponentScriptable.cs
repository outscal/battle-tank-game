using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InputComponent", menuName = "ScriptableObj/InputComponent", order = 2)]
public class InputComponentScriptable : ScriptableObject 
{
    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode turnLeftKey;
    public KeyCode turnRightKey;
    public KeyCode fireKey;
}
