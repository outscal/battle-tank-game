using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace EditorScripts
{
    public class ResetSaveData
    {

        [MenuItem("Tools/Delete PlayerPrefas")]
        public static void ClearPlayerPrefas()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Erased All Saved Data");
        }

    }
}