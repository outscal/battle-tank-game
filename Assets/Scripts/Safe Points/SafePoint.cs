using System;
using UnityEngine;

public class SafePoint : MonoBehaviour
{
    private int _inside =0;
    public bool Safe { get; set; }

    private void Start()
    {
        Safe = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _inside++;
        Safe = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>())
        {
            _inside--;
            Safe = _inside <= 0;
        }
    }
}
