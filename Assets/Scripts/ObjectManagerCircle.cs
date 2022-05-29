using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManagerCircle : MonoBehaviour
{
    //Object we want to add
    public GameObject prefabGO;

    //radius of circle we will add objects inside of
    public float radius = 5f;

    //How many gameObjects we will add each time we press a button
    public int howManyObjects = 5;

    //Are we adding or removing objects within the circle
    public enum Actions { AddObjects, RemoveObjects}

    public Actions action;

    //Add a prefab that we instantiated in the editor script
    public void AddPrefab(GameObject newPrefab, Vector3 center)
    {
        //get a random position within a circle in 2d space
        Vector2 random2DPos = Random.insideUnitCircle * radius;

        //we are in 3D, so we make it 3D and move it where the center is
        Vector3 randomPos = new Vector3(random2DPos.x, 0f, random2DPos.y) + center;

        newPrefab.transform.position = randomPos;
        newPrefab.transform.parent = transform;
    }

    //Get an array with all children to this GameObject
    private GameObject[] GetAllChildren()
    {
        //This array will hold all children
        GameObject[] allChildren = new GameObject[transform.childCount];

        //Fill the array
        int childCount = 0;
        foreach(Transform child in transform)
        {
            allChildren[childCount] = child.gameObject;
            childCount += 1;
        }
        return allChildren;
    }

    //Remove Objects within the circle
    public void RemoveObjects(Vector3 center)
    {
        //get an array with all children to this transform
        GameObject[] allChildren = GetAllChildren();

        foreach(GameObject child in allChildren)
        {
            //if this child is within the circle
            if(Vector3.SqrMagnitude(child.transform.position - center) < radius * radius)
            {
                DestroyImmediate(child);
            }
        }
    }

    //Remove all Objects
    public void RemoveAllObjects()
    {
        //get an array with all children to this transform
        GameObject[] allChildren = GetAllChildren();

        //Now destroy them
        foreach(GameObject child in allChildren)
        {
            DestroyImmediate(child);
        }
    }



}
