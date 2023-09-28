using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool ui_UseRelativeRotation = true;

    private Quaternion ui_RelativeRotation;

    private void Start()
    {
        ui_RelativeRotation = transform.parent.localRotation;
    }

    private void Update()
    {
        if(ui_UseRelativeRotation)
            transform.rotation = ui_RelativeRotation;
    }
}
