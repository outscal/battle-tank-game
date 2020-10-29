using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Enemies",menuName ="Enemy Tank")]
public class EnemyTank : ScriptableObject
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
