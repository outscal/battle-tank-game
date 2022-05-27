using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform playerTank;
    private Vector3 offset;
    public Camera m_camera;
    private float CameraZoomOutSpeed = 0.0001f;


    public void Start()
    {
        playerTank = GameObject.FindObjectOfType<TankView>().transform;
    }

    void Update()
    {
        CheckPlayer();
        transform.position = playerTank.position + offset;
    }

    private void CheckPlayer()
    {
        if (playerTank == null)
        {
            playerTank = transform;
            return;
        }
    }

    private void LateUpdate()
    {
        offset = transform.position - playerTank.position;
    }
    public IEnumerator ZoomOutCamera()
    {
        //Debug.Log("zoom out hoja yaar");
        float lerp = 0.01f;
        //camera.transform.SetParent(null);
        while (m_camera.orthographicSize < 30f)
        {
            m_camera.orthographicSize = Mathf.Lerp(m_camera.orthographicSize, 30f, lerp);
            lerp += CameraZoomOutSpeed;
            yield return new WaitForSeconds(0.01f);
        }

    }
}