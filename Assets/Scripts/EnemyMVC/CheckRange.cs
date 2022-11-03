using UnityEngine;
using System.Collections;
using TankServices;

public class CheckRange : MonoBehaviour
{
    WaitForSeconds waitForSeconds;

    private void Awake()
    {
        waitForSeconds = new WaitForSeconds(3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<TankView>()!=null)
        {
            Debug.Log("player detected!!");
            ServiceEvents.Instance.ChasePlayer?.Invoke();
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<TankView>() != null)
        {
            Debug.Log("player left!!");
            StartCoroutine(StopAfterALittleWhile());
        }
    }

    private IEnumerator StopAfterALittleWhile()
    {
        yield return waitForSeconds;
        ServiceEvents.Instance.StopChase?.Invoke();
    }
}
