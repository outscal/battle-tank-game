using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TankGame.Tank;
using TankGame.Enemy;
using TankGame.Bullet;
using TankGame.Event;

public class SoundManager : MonoSingletonGeneric<SoundManager>
{
    //public static SoundManager instance = null;

    public AudioSource playerSource;
    public AudioSource collectibleSource;
    public AudioSource gameSfxSource;
    public AudioSource gameEffectSource;
    public AudioSource uiSource;

    public PlayerClipping[] playerSounds;
    public CollectibleClipping[] collectibleSound;
    public GameSfxClipping[] gameSound;
    public GameEffectsClipping[] gameEffectSound;
    public UISfxClipping[] uiSound;
    private TankView player;

    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Start()
    {
        base.Start();
        EventService.Instance.PlayerSpawn += GetPLayerAudioSource;
    }


    private void GetPLayerAudioSource()
    {
        player = TankService.Instance.GetCurrentPlayer();
        if (player != null)
        {
            playerSource = player.GetComponent<AudioSource>();
        }
        else
        {
            Debug.Log("player is null");
        }
    }

    [Serializable]
    public class PlayerClipping
    {
        public PlayerSfx playerSfx;
        public AudioClip clip;
    }

    [Serializable]
    public class CollectibleClipping
    {
        public CollectibleSfx collectibleSfx;
        public AudioClip clip;
    }

    [Serializable]
    public class GameSfxClipping
    {
        public GameSfx gameSfx;
        public AudioClip clip;
    }

    [Serializable]
    public class GameEffectsClipping
    {
        public GameSfx gameEffect;
        public AudioClip clip;
    }

    [Serializable]
    public class UISfxClipping
    {
        public UISfx uiSfx;
        public AudioClip clip;
    }


    //public void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else
    //    {
    //        if (instance != null)
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //    DontDestroyOnLoad(gameObject);
    //}



    public void playPlayerSound(PlayerSfx playerSfx, bool isLoop)
    {
        for (int i = 0; i < playerSounds.Length; i++)
        {
            if (playerSounds[(int)playerSfx] == playerSounds[i])
            {
                playerSource.clip = playerSounds[(int)playerSfx].clip;
                playerSource.Play(0);
                playerSource.loop = isLoop;
            }
        }
    }

    public void playCollectibleSound(CollectibleSfx collectibleSfx, bool isLoop)
    {
        collectibleSource.clip = collectibleSound[(int)collectibleSfx].clip;
        collectibleSource.Play(0);
        collectibleSource.loop = isLoop;
    }


    public void playGameSound(GameSfx gameSfx, bool isLoop)
    {
        gameSfxSource.clip = gameSound[(int)gameSfx].clip;
        gameSfxSource.Play(0);
        gameSfxSource.volume = 0.1f;
        gameSfxSource.loop = isLoop;
    }
    public void playGameEffect(GameEffects gameEffect, bool isLoop)
    {
        gameEffectSource.clip = gameEffectSound[(int)gameEffect].clip;
        gameEffectSource.Play(0);
        gameEffectSource.loop = isLoop;
    }



    public void playUiEffectSound(UISfx uiSfx, bool isLoop)
    {

        uiSource.clip = uiSound[(int)uiSfx].clip;
        uiSource.Play(0);
        uiSource.loop = isLoop;
    }


}
