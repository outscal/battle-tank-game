using UnityEngine.UI;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField]private float MaxHealth = 100f;
    [SerializeField]private Slider healthSlider;
    [SerializeField]private Image healthFillImage;
    [SerializeField]private Color fullHealthColor = Color.green;
    [SerializeField]private Color lowHealthColor= Color.red;
    [SerializeField]private GameObject ExplosionPrefab;

    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    private float CurrentHealth;
    private bool IsDead;
 
 
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Awake()
    {
        CurrentHealth=MaxHealth;
        IsDead=false;
        SetHealthColor();
    }


//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    public void TakeDamage(float takeDamage)
    {
        CurrentHealth -=takeDamage;
        SetHealthColor();
        if(CurrentHealth<=0f && !IsDead)
        {
            PlayerDead();
        }
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void SetHealthColor()
    {
        healthSlider.value=CurrentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,fullHealthColor,CurrentHealth/MaxHealth);
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void PlayerDead()
    {
        IsDead = true;
        gameObject.SetActive(false);
    }
}
