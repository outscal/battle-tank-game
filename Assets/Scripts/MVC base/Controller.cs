using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller
{
    public Model model { get; }
    public View view { get; }

    public Controller(Model _model, View _view)
    {
        model = _model;
        view = _view;
    }

   
}
