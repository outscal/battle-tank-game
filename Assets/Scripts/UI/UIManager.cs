using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI AchevementsForShooting;

    [SerializeField]
    private List<string> Achevements;
    [SerializeField]
    private int Duration=3;

    private Coroutine AchevementDisplay ; 

    private void Start()
    {
        AchevementsForShooting.enabled=false;
        TankView.AchevementsUnlock += UnlockAchements;
    }

    private void UnlockAchements(int obj)
    {
        switch (obj)
        {
            case 10:
                AchevementsForShooting.text = Achevements[0];
                break;
            case 25:
                AchevementsForShooting.text = Achevements[1];
                break;
            case 50:
                AchevementsForShooting.text = Achevements[2];
                break;
        }
        
        AchevementDisplay =StartCoroutine(AchevementShow(Duration));
    }

    private IEnumerator AchevementShow(int duration)
    {
        AchevementsForShooting.enabled = true;
        yield return new WaitForSeconds(duration);
        AchevementsForShooting.enabled = false;
    }
}
