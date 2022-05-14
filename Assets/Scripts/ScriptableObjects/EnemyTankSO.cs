using UnityEngine;

[CreateAssetMenu(fileName = "EnemyNewTankSO", menuName = "Scriptable Object/Enemy New Tank SO")]
public class EnemyTankSO : ScriptableObject
{
    public TankType Tanktype;
    public string TankName;
    public float Speed;
    public float Health;
}
