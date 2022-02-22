using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public Control control { get; private set; }
    public Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void setControl(Control control)
    {
        this.control = control;
    }

    public void BulletMove()
    {
        Vector3 move = transform.forward * control.bulletModel.Speed * Time.fixedDeltaTime;
        rb.MovePosition(move);
        Destroy();
    }

    public void Destroy()
    {
        Destroy(gameObject, 2.5f);
    }
}
