using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoxCollider : MonoBehaviour
{
    public static BoxCollider groundboxCollider;
    void Awake()
    {
        groundboxCollider = GetComponent<BoxCollider>();
    }
}
