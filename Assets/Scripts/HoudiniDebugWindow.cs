using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HoudiniDebugWindow : EditorWindow
{
    #region Variables
    public static HoudiniDebugWindow curWindow;
    #endregion

    #region Main Methods
    [MenuItem("Houdini Engine/Launch Debug Window", false, 300)]
    public static void InitWIndow()
    {
        curWindow = (HoudiniDebugWindow)EditorWindow.GetWindow<HoudiniDebugWindow>();
        curWindow.title = "Debug Window";
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("This is Working", EditorStyles.boldLabel);

        if(GUILayout.Button("Get Asset Info", GUILayout.Height(40)))
        {
            Debug.Log("Getting Asset Info");
        }
    }
    #endregion

    #region Utility Methods
    #endregion

}
