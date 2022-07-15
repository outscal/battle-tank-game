using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private EnemyController enemyController;
    public Rigidbody rb;
// Tank health UI
    float lerpSpeed;

     private float currentHealth;
     public Image healthFill;
     public float Startinghealth = 100f;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    

    public void SetEnemyController(EnemyController _enemycontroller)
    {
      enemyController = _enemycontroller;
    }  


    public void OnEnable()
    {
        currentHealth = Startinghealth;
        // tankDead = false;
        SetHealthUI();
       
     
    }

   public Rigidbody GetRigidbody()
   {
     return rb;
   }


// Enemy health
   void SetHealthUI()
    {
        
        healthFill.fillAmount = Mathf.Lerp(healthFill.fillAmount,currentHealth / Startinghealth, lerpSpeed);
        Color Healthcolor = Color.Lerp(m_ZeroHealthColor,m_FullHealthColor,(currentHealth/Startinghealth));
        healthFill.color = Healthcolor;
    }
}


