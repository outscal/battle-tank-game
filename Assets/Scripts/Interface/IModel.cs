using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModel
{
    int Speed { get; }
    float Health { get; }
    int PlayerNumber { get; }
    KeyCode FireKey { get; }
}
