using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using HoudiniEngineUnity;

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
            GameObject curSelected = Selection.activeGameObject;
            if (curSelected)
            {
                GetHoudiniInfo(curSelected);
            }
            else
            {
                DebugMessageWindow("please Selcect an Object");
            }
            
        }
    }


    #endregion

    #region Utility Methods
    private void GetHoudiniInfo(GameObject curSelected)
    {
        HEU_HoudiniAsset curAsset = (HEU_HoudiniAsset)curSelected.GetComponent<HEU_HoudiniAsset>();
        if (curSelected != null)
        {
            //Debug.Log(curAsset.AssetID);
            //Debug.Log(curAsset.AssetId);
            // Debug.Log(curAsset.AssetHelp);
            // Debug.Log(curAsset.AssetName);
            Debug.Log("Houdini Asset Clicked");
        }
        else
        {
            Debug.Log("Selected is not a Houdini Asset");
        }
        Debug.Log("Getting Asset Info");
        throw new NotImplementedException();
    }

    void DebugMessageWindow(string message)
    {
        EditorUtility.DisplayDialog("Debug Method", message, "OK");
    }
    #endregion

}
