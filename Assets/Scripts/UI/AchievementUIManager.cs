using Singleton;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementUIManager : MonoSingletonGeneric<AchievementUIManager>
{
    [SerializeField]
    private Text displayMessage;

    public void DisplayAchievement(string achievementText)
    {
        displayMessage.text = "Achievement Unlocked : " + achievementText;
        StartCoroutine(ShowAchievementTextAnim());
    }

    private IEnumerator ShowAchievementTextAnim()
    {
        Animator displayMessageAnim = displayMessage.GetComponent<Animator>();
        displayMessageAnim.SetBool("setDropDown", true);
        yield return new WaitForSeconds(2);
        displayMessageAnim.SetBool("setDropDown", false);
    } 
    
}
