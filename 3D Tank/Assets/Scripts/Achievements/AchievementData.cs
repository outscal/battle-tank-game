using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "Achievement Data", menuName = "Achievements", order = 54)]
public class AchievementData : ScriptableObject
{
    [Header("Achievement Types")]
    public AchievementTypes types;

    [Header("Achievement Title")]
    public string Title;

    [Header("Achievement Description")]
    public string Description;
}
