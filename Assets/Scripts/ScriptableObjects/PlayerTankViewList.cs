using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Creates a Scriptable Object that holds all the different Player Tank Views in a List.
/// </summary>

[CreateAssetMenu(fileName = "PlayerTankViewList", menuName = "ScriptableObjects/NewPlayerTankViewList")]
public class PlayerTankViewList : ScriptableObject
{
    public List<TankView> playerTankViewList;
}
