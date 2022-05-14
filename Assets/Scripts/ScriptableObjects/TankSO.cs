using UnityEngine;

[CreateAssetMenu(fileName = "NewTankSO", menuName = "Scriptable Object/New Tank SO")]
public class TankSO : ScriptableObject
{
    public TankType Tanktype;
    public string TankName;
    public float Speed;
    public float Health;
}
