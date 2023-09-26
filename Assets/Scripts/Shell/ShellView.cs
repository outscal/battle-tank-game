using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellView : MonoBehaviour
{
    private ShellController ShellController { get; set; }
    public void SetShellController(ShellController shellController)
    {
        ShellController = shellController;
    }

    public Rigidbody GetRigidbody() 
    {
        return GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //GetComponent<Rigidbody>();
       
        if (ShellController != null)
        {
            ShellController.Shot();
        }
        else
        {
            return;
        }
        
    }

    private void Update()
    {
        Destroy(gameObject, 5f);
    }
}
