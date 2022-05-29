using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ObjectManagerCircle))]
public class ObjectManagerEditor : Editor
{
    private ObjectManagerCircle objectManager;

    //the Center of the circle
    private Vector3 center;

    private void OnEnable()
    {
        objectManager = target as ObjectManagerCircle;

        //Hide the handles of GameObject. so we don't move it instead of moving the circle
        Tools.hidden = true;
    }

    private void OnDisable()
    {
        //Un-hide the handles of GameObject
        Tools.hidden = false;
    }

    private void OnSceneGUI()
    {
        //Move the circle when moving the mouse
        //A ray from the mouse position

        Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            ///WHere did it hit the ground
            center = hit.point;

            //Need to tell unity that we have moved the circle or circle may be displayed at the old position
            SceneView.RepaintAll();
        }

        //Display the circle
        Handles.color = Color.red;

        Handles.DrawWireDisc(center, Vector3.up, objectManager.radius);
        //Add or remove objects with left mouse click

        //First make sure we can't select another gameObject in the scene we click
        HandleUtility.AddDefaultControl(0);

        //Have we clicked with the left mouse button?

        if(Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            //Should we add or remove object
            if(objectManager.action == ObjectManagerCircle.Actions.AddObjects)
            {
                AddNewPrefabs();
                MarkSceneAsDirty();
            }
            else if(objectManager.action == ObjectManagerCircle.Actions.RemoveObjects)
            {
                objectManager.RemoveObjects(center);
                MarkSceneAsDirty();
            }
        }

    }

    //Add buttons this scripts inspector
    public override void OnInspectorGUI()
    {
        //Add the default stuff
        DrawDefaultInspector();

        //Remove all objects when pressing a button
        if(GUILayout.Button("Remove all objects"))
        {
            //Pop-up so you don't actually remove all objects
            if(EditorUtility.DisplayDialog("Safety Check, Do you remove all objects", "Yes", "No"))
            {
                objectManager.RemoveAllObjects();
                MarkSceneAsDirty();
            }
        }
    }

    //Force unity to save changes or unity may not save when we have instantiated/remove prefab despite pressing save button
    private void MarkSceneAsDirty()
    {
        UnityEngine.SceneManagement.Scene activeScene = UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene();

        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(activeScene);
    }

    //Instantiate prefab at random positions within the circle
    private void AddNewPrefabs()
    {
        //How many prefab do we want
        int howManyObjects = objectManager.howManyObjects;

        //Which prefab we want to add
        GameObject prefabGO = objectManager.prefabGO;

        for(int i = 0; i < howManyObjects; i++)
        {
            GameObject newGO = PrefabUtility.InstantiatePrefab(prefabGO) as GameObject;

            //send it to the main script to add it at a random position within the circle
            objectManager.AddPrefab(newGO, center);
        }
    }
}
