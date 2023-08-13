using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BattleTank;

public class CameraController : MonoBehaviour
{
   
    private Transform playertransform;
    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomOutSpeed = 0.05f;
    [SerializeField] float offsetLevel = 0.01f;
    Vector3 currentPos;
    private void Start()
    {
        playertransform = gameObject.transform.Find("Player");
        if (playertransform == null)
        {
            Debug.Log("Player Not Found");
        }
        else
        {
            Debug.LogError("Player Found");
        }
       
    }

   public void SetTankTransform(Transform _transform)
    {
        playertransform = _transform;
        if (playertransform != null)
        {
            currentPos = playertransform.position;
        }
    }
    void LateUpdate()
    {
        if (playertransform != null)
        {
            transform.position += playertransform.position - currentPos;
            currentPos = playertransform.position;
        }
    }
    public IEnumerator ZoomOut()
    {
        while (mainCamera.orthographicSize < 19)
        {
            mainCamera.orthographicSize += offsetLevel;
            yield return new WaitForSeconds(zoomOutSpeed);
        }
    }
}
