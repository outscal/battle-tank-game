using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Controller
{
    public Tank_Controller(Tank_Model tankmodel, Tank_View tankPrefab)
    {
        Tank_Model = tankmodel;
        Tank_View = GameObject.Instantiate<Tank_View>(tankPrefab);
        Debug.Log("Tank_Controller()", Tank_View);
    }
    public Tank_Model Tank_Model { get; }
    public Tank_View Tank_View { get; }
}
