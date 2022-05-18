using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image image;
    public TankController tankController;

    public void Start()
    {

    }
    public void SetMaxHealth(float health)
    {
        image.fillAmount = health;
    }
    public void SetHealth(float health)
    {
        image.fillAmount = health;
    }
   
}
