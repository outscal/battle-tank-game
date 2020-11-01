using UnityEngine;

public class cameraController : MonoBehaviour
{

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;


    void Update()
    {
        transform.position= target.position + offset;
    }
}
