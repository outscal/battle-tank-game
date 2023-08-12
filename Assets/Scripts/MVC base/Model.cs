using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model
{
    public Controller controller { get; private set; }

    public Model() { }

    public void getController(Controller _controller)
    {
        controller = _controller;
    }
}
