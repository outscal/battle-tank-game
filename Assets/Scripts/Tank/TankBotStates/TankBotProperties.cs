using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankBattle.Tank
{
    [CreateAssetMenu(fileName = "TankBotProperties", menuName = "ScriptableObject/TankBotProperties", order = 0)]
    public class TankBotProperties : ScriptableObject
    {
        public float EnemyDetectionRadius;
        public float AttackTriggerDistance;
    }
}
