using System;
using UnityEditor;
using UnityEngine;

public class AchivementService : MonoSingletonGeneric<AchivementService> 
{
    private int noOfBulletPlayerFired;
    private int noOfTimesPlayerDied;
    private int noOfTimePlayerEscaped;
    void Start()
    {
        EventService.Instance.OnPlayerBulletFire += AchivementService_OnPlayerBulletFire;
        EventService.Instance.OnPlayerDead += AchivementService_OnPlayerDead;
        EventService.Instance.OnPlayerEscapeFromChasingTank += AchivementService_OnPlayerEscapeFromChasingTank;
        noOfBulletPlayerFired = PlayerPrefs.GetInt(nameof(noOfBulletPlayerFired),0);
        noOfTimesPlayerDied = PlayerPrefs.GetInt(nameof(noOfTimesPlayerDied),0);
        noOfTimePlayerEscaped = PlayerPrefs.GetInt(nameof(noOfTimePlayerEscaped),0);
    }


    private void AchivementService_OnPlayerEscapeFromChasingTank()
    {
        noOfTimePlayerEscaped++;
        PlayerPrefs.SetInt(nameof(noOfTimePlayerEscaped), noOfTimePlayerEscaped);
        switch (noOfTimePlayerEscaped)
        {
            case 1:
                Debug.Log("Achivement Unlocked: Bye Bye B****!");
                break;
            case 10:
                Debug.Log("Achivement Unlocked: You Know how to drive!");
                break;
            case 10000:
                Debug.Log("Achivement Unlocked: OMG YOU NEED TO TOUCH GRASS!");
                break;
        }
    }
    private void AchivementService_OnPlayerDead()
    {
        noOfTimesPlayerDied++;
        PlayerPrefs.SetInt(nameof(noOfTimesPlayerDied), noOfTimesPlayerDied);
        switch (noOfTimesPlayerDied)
        {
            case 1:
                Debug.Log("Achivement Unlocked: Its Just a start Dont Give up");
                break;
            case 10:
                Debug.Log("Achivement Unlocked: Dont worry, you will Improve");
                break;
            case 10000:
                Debug.Log("Achivement Unlocked: Its time to give up!");
                break;
        }

    }
    private void AchivementService_OnPlayerBulletFire()
    {
        noOfBulletPlayerFired++;
        PlayerPrefs.SetInt(nameof(noOfBulletPlayerFired), noOfBulletPlayerFired);
        switch (noOfBulletPlayerFired)
        {
            case 10:
                Debug.Log("Achivement Unlocked: 10 bulletfired ");
                break;
            case 25:
                Debug.Log("Achivement Unlocked: 25 bulletfired ");
                break;
            case 50:
                Debug.Log("Achivement Unlocked: 50 bulletfired ");
                break;
        }

    }
    
    private void OnDestroy()
    {
        EventService.Instance.OnPlayerBulletFire -= AchivementService_OnPlayerBulletFire;
    }
}
