using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurrent : MonoBehaviour
{
    public Joystick joystick;
    public float rotSpeed = 3f;
    [SerializeField]
    private float rotationSpeed=2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotationTurrent();
    }
    private void RotationTurrent()
    {
        Vector3 move = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Quaternion targetRotation = Quaternion.LookRotation(move, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

    }
}
