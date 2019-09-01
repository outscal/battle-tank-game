using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenOverlayManager : GenericMonoSingleton<ScreenOverlayManager>
{
    public GameObject TankHealthsliderObject;

    private Slider tankHealthBar;
    
    void Start()
    {
        tankHealthBar = TankHealthsliderObject.GetComponent<Slider>();
    }

    public void SetTankHealthTo(float healthPercent)
    {
        tankHealthBar.value = healthPercent;
    }

    void Update()
    {
        
    }
}
