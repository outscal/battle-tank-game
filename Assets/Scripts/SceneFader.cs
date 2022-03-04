using System.Collections;
using Tank;
using Tank.Interfaces;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    #region Serialized Data members

    [SerializeField] private GameObject[] objects;
    [SerializeField] private float fadingTime;

    #endregion

    #region Unity Functions

    private void Start()
    {
        PlayerTankService.Instance.Player.PlayerDied += FadeOut;
    }

    #endregion

    #region Private Functions

    private void FadeOut()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        foreach (var tank in EnemyTankService.Instance.Tanks)
        {
            StartCoroutine(((ITankService) EnemyTankService.Instance).KillTank(tank, EnemyTankService.Instance.Explosion));
            yield return new WaitForSeconds(fadingTime);
        }
        foreach (var thing in objects)
        {
            Destroy(thing);
            yield return new WaitForSeconds(fadingTime);
        }
    }

    #endregion
}
