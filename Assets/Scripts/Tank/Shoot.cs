using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoSingletonGeneric<Shoot>
{


    [SerializeField]
    private GameObject shell;

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject Fire(Transform firePoint)
    {
        GameObject obj = Instantiate(shell, firePoint.position,firePoint.rotation);
        return obj;
    }
}
