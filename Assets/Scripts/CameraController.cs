using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    float hor, vert;
    Vector3 currentPos;
    void Start()
    {
        currentPos = player.position;
    }
    void Update()
    {
        transform.position += player.position - currentPos;
        currentPos = player.position;
    }
}
