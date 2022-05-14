using UnityEngine;

[CreateAssetMenu(fileName = "NewTankListSO", menuName = "Scriptable Object/New TankList ScriptableObject")]
public class TankListSO : ScriptableObject
{
    public TankSO[] tanks;
}