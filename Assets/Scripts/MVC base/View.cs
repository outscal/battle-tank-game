using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    public Controller controller { get; private set; }

    public View() { }

    public void getController(Controller _controller)
    {
        controller = _controller;
    }
}
