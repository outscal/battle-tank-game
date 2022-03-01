using System;
using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

public class SceneFader : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    [SerializeField] private float fadingTime;

    private void Start()
    {
        PlayerTankService.Instance.Player.PlayerDied += FadeOut;
    }

    private void FadeOut()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        foreach (var tank in EnemyTankService.Instance.Tanks)
        {
            yield return ((ITankService) EnemyTankService.Instance).KillTank(tank, EnemyTankService.Instance.Explosion);
        }
        foreach (var thing in objects)
        {
            GameObject.Destroy(thing);
            yield return new WaitForSeconds(fadingTime);
        }
    }
}
