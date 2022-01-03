using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapController : MonoBehaviour
{
    public Transform player;
    public GameObject openMiniMap;
    public GameObject miniMap;
    public Button openingButton;
    public Slider zooming;
    public Camera miniMapCam;
    private int maxCamSize = 40;

    public void Start()
    {
        miniMapCam = gameObject.GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zooming.maxValue = maxCamSize;
        miniMapCam.orthographicSize = 30;
    }
    public void Update()
    {
        miniMapCam.orthographicSize = zooming.value;
    }
    void LateUpdate()
    {
        Vector3 newPos = player.position;
        newPos.y = transform.position.y;
        transform.position = newPos;
    }
    public void OpenMiniMap()
    {
        openMiniMap.gameObject.SetActive(true);
        miniMap.gameObject.SetActive(false);
    }
    public void CloseMiniMap()
    {
        openMiniMap.gameObject.SetActive(false);
        miniMap.gameObject.SetActive(true);
    }
}
