using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private TankView player;
    private Vector3 offset;
    public Camera m_camera;
    private float CameraZoomOutSpeed = 0.0001f;


    public void Start()
    {
        player = GameObject.FindObjectOfType<TankView>();
    }

    void Update()
    {
        CheckPlayer();
        transform.position = player.transform.position + offset;
    }

    private void CheckPlayer()
    {
        if (player == null)
        {
            player.transform.position = transform.position;
            return;
        }
    }

    private void LateUpdate()
    {
        offset = transform.position - player.transform.position;
    }
    public IEnumerator ZoomOutCamera()
    {
        float lerp = 0.01f;
        m_camera.transform.SetParent(null);
        while (m_camera.orthographicSize < 30f)
        {
            m_camera.orthographicSize = Mathf.Lerp(m_camera.orthographicSize, 30f, lerp);
            lerp += CameraZoomOutSpeed;
            yield return new WaitForSeconds(0.01f);
        }

    }
}