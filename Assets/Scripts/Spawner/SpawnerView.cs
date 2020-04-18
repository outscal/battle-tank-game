using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerView : MonoBehaviour
{

    private Vector3 instancePos;

    public void setPosition(SpawnerModel model) {
        Debug.Log("set position called");
        instancePos = model.SpawnPos;
        //Debug.Log(instancePos);
        transform.position = instancePos;
    }
}
