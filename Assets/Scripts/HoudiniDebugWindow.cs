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
        HEU_SessionBase session = HEU_SessionManager.GetOrCreateDefaultSession();
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

        if (GUILayout.Button("Get HDA info", GUILayout.Height(40)))
        {
            GameObject curSelected = Selection.activeGameObject;
            if (curSelected)
            {
                GetHDAInfo(curSelected);
            }
            else
            {
                DebugMessageWindow("please Selcect an Object");
            }

        }

        if(GUILayout.Button("Instantiate", GUILayout.Height(40)))
        {
            GameObject curSelected = Selection.activeGameObject;
            if (curSelected)
            {
                HEU_HoudiniAssetRoot root = (HEU_HoudiniAssetRoot)curSelected.GetComponent<HEU_HoudiniAssetRoot>();
                if(root != null)
                {
                    InstantiateHDA(root._houdiniAsset.AssetPath);
                }
                else
                {
                    DebugMessageWindow("Selected Object is not an HDA");
                }
            }
            else
            {
                Debug.Log("Please select an Object");
            }
        }

        if (GUILayout.Button("Parameters", GUILayout.Height(40)))
        {
            GameObject curSelected = Selection.activeGameObject; 
            HEU_HoudiniAsset tempAsset = curSelected.GetComponent<HEU_HoudiniAssetRoot>()._houdiniAsset;
            List<HEU_ParameterData> parms = tempAsset.Parameters.GetParameters();
            
            foreach (HEU_ParameterData parmData in parms)
            {
                Debug.Log("Parameter is " + parmData._labelName);

                if (parmData._parmInfo.type == HAPI_ParmType.HAPI_PARMTYPE_BUTTON)
                {
                    EditorGUILayout.LabelField(parmData._labelName);
                    // Display a button: parmData._intValues[0];

                }
                else if (parmData._parmInfo.type == HAPI_ParmType.HAPI_PARMTYPE_FLOAT)
                {
                    // Display a float: parmData._floatValues[0];

                    // You can set a float this way
                    HEU_ParameterUtility.SetFloat(tempAsset, parmData._name, 1f);

                    // Or this way (the index is 0, unless its for array of floats)
                    parmData._floatValues[0] = 1;
                }

            }
        }

        GUILayout.Space(30); //Creates space between buttons
        GameObject selectedObj = Selection.activeGameObject;
        if (selectedObj)
        {
            DrawAssetParms(selectedObj);
        }
        else
        {
            EditorGUILayout.LabelField("No Asset Selected");
        }

        Repaint();
    }

    #endregion

    #region Utility Methods
    private void GetHoudiniInfo(GameObject curSelected)
    {
        HEU_HoudiniAssetRoot root;
        HEU_HoudiniAsset curAsset = (HEU_HoudiniAsset)curSelected.GetComponent<HEU_HoudiniAsset>();
        if (curSelected != null)
        {
            Debug.Log(curAsset.AssetID);
            Debug.Log(curAsset.AssetHelp);
            Debug.Log(curAsset.AssetInfo);
            Debug.Log(curAsset.AssetType);
            Debug.Log(curAsset.AssetPath);
            Debug.Log("Houdini Asset Clicked");
            
        }
        else
        {
            Debug.Log("Selected is not a Houdini Asset");
        }
        
    }

    private void GetHDAInfo(GameObject curSelected)
    {
        HEU_HoudiniAssetRoot root = (HEU_HoudiniAssetRoot)curSelected.GetComponent<HEU_HoudiniAssetRoot>();
        HEU_Parameters curParms = root._houdiniAsset.Parameters;
        if(curParms != null)
        {
           // HAPI_ParmInfo[] parmInfo = curParms._paramChoices;
        }
        else
        {

        }
        if (root)
        {
            Debug.Log(root._houdiniAsset.AssetPath);
            Debug.Log(root._houdiniAsset.AssetName);
            Debug.Log(root._houdiniAsset.AssetInfo);
            Debug.Log(root._houdiniAsset.AssetID);
            Debug.Log(root._houdiniAsset.Parameters);
        }
        else
        {
            Debug.Log("Not an HDA");
        }
    }

    void DebugMessageWindow(string message)
    {
        EditorUtility.DisplayDialog("Debug Method", message, "OK");
    }

    private void InstantiateHDA(string assetPath)
    {
        GameObject curSelected = Selection.activeGameObject;
        HEU_HoudiniAsset curAsset = (HEU_HoudiniAsset)curSelected.GetComponent<HEU_HoudiniAsset>();
        HEU_HoudiniAssetRoot root = (HEU_HoudiniAssetRoot)curSelected.GetComponent<HEU_HoudiniAssetRoot>();
        if (!string.IsNullOrEmpty(assetPath))
        {
            Debug.Log(assetPath);
            GameObject go =  HEU_HAPIUtility.InstantiateHDA(assetPath, Vector3.zero, HEU_SessionManager.GetOrCreateDefaultSession(), true);
            Debug.Log("Go init" + go.name);          
        }
        else
        {
            DebugMessageWindow("Cannot Instantiate HDA");
        }
    }

    private void DrawAssetParms(GameObject selectedGO)
    {
        HEU_HoudiniAssetRoot curHDA = (HEU_HoudiniAssetRoot)selectedGO.GetComponent<HEU_HoudiniAssetRoot>();
        HEU_HoudiniAsset asset;
        if(curHDA != null)
        {
            HEU_Parameters curParms = curHDA._houdiniAsset.Parameters;
            if(curHDA != null)
            {
                EditorGUI.BeginChangeCheck();

                if (EditorGUI.EndChangeCheck())
                {

                }
                float curValue = 0.5f;
                curValue = EditorGUILayout.Slider(curValue, 0f, 10f);
                Debug.Log("Parametrs section");
            }
            else
            {

            }
        }
        //throw new NotImplementedException();
    }

    #endregion

}
 