using System.Collections;
using UnityEngine;
using TMPro;
public class AchievementScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] TMP_Text achievementMessage;
    public void SetLocalTransform()
    {
        transform.localScale = Vector3.one;
        transform.localPosition = new Vector3(0, 270, 0);
    }
    public void SetMessage(string _message)
    {
        achievementMessage.text = _message;
    }
    public void ShowcaseAchievement()
    {
        animator.SetTrigger("Showcase");
        StartCoroutine(DestroyTimer(6f));
    }
    IEnumerator DestroyTimer(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(this.gameObject);
    }
}
