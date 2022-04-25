using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AchievementScriptableObjectList", menuName = "ScriptableObjects/Achievement/NewAchievementListScriptableObject")]
public class AchievementSOList : ScriptableObject
{
    public bulletFiredAchievementSO bulletsFiredAchievementSO;
    public enemiesKilledAchievementSO enemiesKilledAchievementSO;
}