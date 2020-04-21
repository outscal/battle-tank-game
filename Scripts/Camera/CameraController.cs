using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commons;
using Cinemachine;
public class CameraController : GenericSingleton<CameraController>
{
    private CinemachineVirtualCamera virtualCamera;

    protected override void Awake()
    {
        base.Awake();
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }
    public void SetTarget(Transform taregt)
    {
        virtualCamera.Follow = taregt;
    }
}
