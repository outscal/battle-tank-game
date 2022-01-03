using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartPortal());
            Invoke("HoldTank", 1f);
        }
    }
    void HoldTank()
    {
        TankController.Instance.enabled = false;
    }
    IEnumerator StartPortal()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(3);
    }
}
