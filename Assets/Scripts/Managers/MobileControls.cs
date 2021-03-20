using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [HideInInspector]
    public Canvas canvas;
    List<ClickTracker> buttons = new List<ClickTracker>();

    public static MobileControls instance;

    void Awake()
    {
        //Assign this sript to static variable, so it can be accessed from other scripts. Make sure there is only one MobileControls in the Scene.
        instance = this;

        canvas = GetComponent<Canvas>();
    }

    public int AddButton(ClickTracker button)
    {
        buttons.Add(button);

        return buttons.Count - 1;
    }

    public Vector2 GetJoystick(string joystickName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == joystickName)
            {
                return buttons[i].GetInputAxis();
            }
        }

        Debug.LogError("Joystick with a name '" + joystickName + "' not found. Make sure ClickTracker is assigned to the button and the name is matching.");

        return Vector2.zero;
    }

    public bool GetMobileButton(string buttonName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == buttonName)
            {
                return buttons[i].GetHoldStatus();
            }
        }

        Debug.LogError("Button with a name '" + buttonName + "' not found. Make sure ClickTracker is assigned to the button and the name is matching.");

        return false;
    }

    public bool GetMobileButtonDown(string buttonName)
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].buttonName == buttonName)
            {
                return buttons[i].GetClickedStatus();
            }
        }

        Debug.LogError("Button with a name '" + buttonName + "' not found. Make sure ClickTracker is assigned to the button and the name is matching.");

        return false;
    }
}