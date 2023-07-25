using System;
using UnityEditor;
using UnityEngine;

public class AchivementService : MonoSingletonGeneric<AchivementService> 
{
    private int noOfBulletPlayerFired;
    // Start is called before the first frame update
    void Start()
    {
        BulletService.Instance.OnPlayerBulletFire += AchivementService_OnPlayerBulletFire;
        noOfBulletPlayerFired = PlayerPrefs.GetInt(nameof(noOfBulletPlayerFired),0);
    }

    private void AchivementService_OnPlayerBulletFire()
    {
        noOfBulletPlayerFired++;
        PlayerPrefs.SetInt(nameof(noOfBulletPlayerFired), noOfBulletPlayerFired);
        if (noOfBulletPlayerFired == 10)
        {
            Debug.Log("Player Achivement 10 bulletfired unlocked");
        }
        else if(noOfBulletPlayerFired == 25)
        {
            Debug.Log("Player Achivement 25 bulletfired unlocked");
        }
        else if(noOfBulletPlayerFired == 50)
        {
            Debug.Log("Player Achivement 50 bulletfired unlocked");
        }
    }
    private void OnDestroy()
    {
        BulletService.Instance.OnPlayerBulletFire -= AchivementService_OnPlayerBulletFire;
    }
}
