using UnityEngine;

[CreateAssetMenu(fileName = "PlayerTankScriptableObject", menuName = "ScriptableObjects/Tank/Player")]
public class PlayerTankScriptableObject : TankScriptableObject
{
    [SerializeField]
    PlayerTankView playerTankViewPrefab;
    public PlayerTankView PlayerTankViewPrefab { get { return playerTankViewPrefab; } }

    protected new TankCategory tankCategory = TankCategory.Player;
}