using UnityEngine;
using UnityEngine.UI;

public class TankView : MonoBehaviour
{

    private TankController tankController;
    
    
    private float movementInput;
    private float rotationInput;

    private float currentHealth;

    public float Startinghealth = 100f;
    public Rigidbody rb;

    //  private bool tankDead;

     float lerpSpeed;

     
     public Image healthFill;
    public Color m_FullHealthColor = Color.green;
    public Color m_ZeroHealthColor = Color.red;
    // public GameObject m_ExplosionPrefab;
    
    
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        GetInput();
        if(movementInput != 0)
        {
           
           tankController.Move(movementInput);
           
        }
          
        if(rotationInput != 0)
        {
           tankController.Rotate(rotationInput);
           
        } 
        /// <summary>
        /// Line 26 to 34 inside a separate function to clean up monobehaviour life cycle;
        /// </summary>
        
    }

    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput =  Input.GetAxis("Horizontal");
    }

    

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
