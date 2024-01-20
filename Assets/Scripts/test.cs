using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test 
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator Pass()
    {
        yield return new WaitForSeconds(5f);
        Physics.gravity *= 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
