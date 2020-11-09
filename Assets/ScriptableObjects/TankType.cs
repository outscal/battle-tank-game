using UnityEngine;

[CreateAssetMenu(fileName = "Tank-Type", menuName = "Tank-Type")]
public class TankType : ScriptableObject
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private float payrollSpeed;
    [SerializeField]
    private int dmg;


    public int getHP() { return hp; }
    public float getSpd() { return payrollSpeed; }
    public int getDmg() { return dmg; }


}