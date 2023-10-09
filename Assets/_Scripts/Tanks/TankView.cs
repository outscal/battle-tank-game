using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TankView : MonoBehaviour
{
    private TankController tankController;
    public TankType TankType;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        if(image == null)
        {
            Debug.LogError("Image not found");
        }
    }

    private void Start()
    {
        Debug.Log("Tank view Created");

        if (image != null)
        {
            Debug.Log("Image Found");
        }
    }
}
