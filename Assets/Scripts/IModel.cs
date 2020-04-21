using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModel
{
    int M_Speed { get; }
    float M_Health { get; }
    int M_PlayerNumber { get; }
    KeyCode FireKey { get; }
}
