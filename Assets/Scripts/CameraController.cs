using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
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
}
