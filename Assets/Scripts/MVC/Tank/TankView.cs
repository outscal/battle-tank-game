using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{

    private TankController tankController;
    
    
    private float movementInput;
   

    
    public Rigidbody rb;

   

     // TANK HEALTH
     float lerpSpeed;

    private float rotationInput;

    private float currentHealth;
     public Image healthFill;
     public float Startinghealth = 100f;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    
     
    // Tank Death
    //  private bool tankDead;
    // public GameObject m_ExplosionPrefab;
    
    
   
    void Start()
    {
        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f,3f,-5f);
        
    }


     public void OnEnable()
    {
        currentHealth = Startinghealth;
        // tankDead = false;
        SetHealthUI();
       
     
    }

   
    void Update()
    {
        // Tank Movement
        GetInput();
        if(movementInput != 0)
        {
           
           tankController.Move(movementInput);
           
        }
          
        if(rotationInput != 0)
        {
           tankController.Rotate(rotationInput);
           
        } 
       
        
    }


   // User Input
    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput =  Input.GetAxis("Horizontal");
    }

    
   // Health 
    void SetHealthUI()
    {
        
        healthFill.fillAmount = Mathf.Lerp(healthFill.fillAmount,currentHealth / Startinghealth, lerpSpeed);
        Color Healthcolor = Color.Lerp(m_ZeroHealthColor,m_FullHealthColor,(currentHealth/Startinghealth));
        healthFill.color = Healthcolor;
    }


    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;

    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    
}
