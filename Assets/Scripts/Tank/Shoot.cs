using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private GameObject shell;
    [SerializeField]
    private Button firebutton;
    // Start is called before the first frame update
    void Start()
    { 
        firebutton.onClick.AddListener(Fire);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Fire()
    {
        Instantiate(shell, firePoint.position,firePoint.rotation);
    }
}
