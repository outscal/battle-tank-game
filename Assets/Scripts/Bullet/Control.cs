using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Model bulletModel { get; private set; }
    public View bulletView { get; private set; }
    private Rigidbody rb;

    public Control(Model bulletModel, View bulletView, Vector3 position, Quaternion rotation)
    {
        this.bulletModel = bulletModel;
        bulletView = GameObject.Instantiate<View>(bulletView, position, rotation);
        rb = bulletView.gameObject.GetComponent<Rigidbody>();
        bulletView.setControl(this);
        bulletModel.setControl(this);

    }


}
