using UnityEngine;
using TMPro;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject achievementGO;
    [SerializeField] TMP_Text achievementMessage;
    void Start()
    {
        TankService.Instance.PlayerFiredBullet += UnlockAchievement;
    }
    public void UnlockAchievement(string _achievement)
    {
        achievementMessage.text = _achievement;
    }
    void OnDestroy()
    {
        TankService.Instance.PlayerFiredBullet -= UnlockAchievement;
    }
}
