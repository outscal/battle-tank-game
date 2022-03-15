using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    //Summary//
    //Script to Change the btw the given Joystick Mode in the game
    //-Summary//
    public class JoystickController : GenericSingleton<JoystickController>
    {
        public Joystick joystick1;
        public Joystick horizontalJoystick;
        public Joystick verticalJoystick;

        [SerializeField] Button trigger1;
        [SerializeField] Button trigger2;
        [SerializeField] Button exitBtn; 

        public bool joystick1_isActive = true;
        public bool joystick2_isActive = false;


    //method to set default joystick 
    private void Start()              
        {
            horizontalJoystick.gameObject.SetActive(false);
            verticalJoystick.gameObject.SetActive(false);
            trigger2.gameObject.SetActive(false);
        }
        
        //method to set 2nd joystick active and making default one inactive
        public void altActivate1()
        {
            joystick1_isActive = false;
            joystick2_isActive = true;

            joystick1.gameObject.SetActive(false);
            horizontalJoystick.gameObject.SetActive(true);
            verticalJoystick.gameObject.SetActive(true);
            trigger1.gameObject.SetActive(false);
            trigger2.gameObject.SetActive(true);
        }

        //method to set default joystick active and 2nd joystick inactive
        public void altActivate2()
        {
            joystick1_isActive = true;
            joystick2_isActive = false;

            joystick1.gameObject.SetActive(true);
            horizontalJoystick.gameObject.SetActive(false);
            verticalJoystick.gameObject.SetActive(false);
            trigger1.gameObject.SetActive(true);
            trigger2.gameObject.SetActive(false);
        }

       //method to take input for the UI exit button
       private void Exitbtn()
       {
          exitBtn.onClick.AddListener(Exit);
       }
        
        //method to exit the current level to main menu
        void Exit()
        {
          SceneManager.LoadScene("Main Menu");
        }
    }

