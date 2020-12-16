using System;
using UnityEngine;

public class GameEvents : MonoSingletonGeneric<GameEvents>
{
    public  event Action OnPlayerKill;
    public  event Action OnFirstKill;
    public  event Action OnFirstWaveClear;
    int count;

    private void Start()
    {
        count = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length < count) {
            count = GameObject.FindGameObjectsWithTag("Enemy").Length;
            OnPlayerKill?.Invoke();
        }
    }
    public void FirstKillTrigger()
    {
        OnFirstKill?.Invoke();
    }
}
