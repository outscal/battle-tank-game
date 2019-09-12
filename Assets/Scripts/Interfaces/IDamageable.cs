using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankBattle.Tank;

public interface IDamageable
{
    bool TakeDamage(int damage, TankController sourceTank);
}