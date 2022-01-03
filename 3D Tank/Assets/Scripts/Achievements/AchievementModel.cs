using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementModel : MonoBehaviour
{
    public AchievementModel(AchievementData data)
    {
        TitleText = data.Title;
        DescriptionText = data.Description; 
    }

    public string TitleText { get; }
    public string DescriptionText { get; }
}
