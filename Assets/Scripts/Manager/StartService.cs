using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using Interfaces;
using AchievementM;
using Reward;
using Manager;
using Bullet;
using Replay;
using Inputs;
using Enemy;
using Audio;

public class StartService : Singleton<StartService>
{
    [SerializeField]
    private List<IService> services;

    public AudioSource bgSource, fxSource;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        services = new List<IService>();

        RegisterService<IGameManager>(new GameManager());

        RegisterService<IReward>(new RewardManager());

        RegisterService<IAchievement>(new AchievementManager());

        RegisterService<IBullet>(new BulletManager());

        RegisterService<IReplay>(new ReplayManager());

        RegisterService<IInput>(new InputManager());

        RegisterService<IEnemy>(new EnemyManager());

        RegisterService<IAudio>(new AudioManager());
    }

    public void RegisterService<T>(T service) where T : IService
    {
        services.Add(service);
    }

    public T GetService<T>() where T : IService
    {
        T service = default(T);

        foreach (var item in services)
        {
            if (item is T)
            {
                service = (T)item;
                break;
            }
        }

        return service;
    }

    private void Update()
    {
        for (int i = 0; i < services.Count; i++)
        {
            services[i].OnUpdate();
        }
    }
}
