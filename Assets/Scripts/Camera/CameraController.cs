using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Camera mainCamera;
    [SerializeField] float zoomOutSpeed = 0.05f;
    [SerializeField] float offsetLevel = 0.01f;
    Vector3 currentPos;
    public void SetTankTransform(Transform _transform)
    {
        player = _transform;
        if (player != null)
        {
            currentPos = player.position;
        }
    }
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position += player.position - currentPos;
            currentPos = player.position;
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
