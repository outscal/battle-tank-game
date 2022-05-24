using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AchievementHolder", menuName = "ScriptableObjects/Achievement/NewAchievementListSO")]
public class AchievementHolder : ScriptableObject
{
    public BulletFiredAchievementSO bulletsFiredAchievementSO;
    public EnemiesKilledAchievementSO enemiesKilledAchievementSO;
}
