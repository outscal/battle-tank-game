using System;
using Tank;
using UnityEngine;

public class SafePoint : MonoBehaviour
{
    private int _inside ;
    public bool Safe { get; set; }

    private void Start()
    {
        _inside = 0;
        Safe = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyTankView>())
        {
            _inside++;
            Safe = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EnemyTankView>())
        {
            _inside--;
            Safe = _inside <= 0;
        }
    }
}
