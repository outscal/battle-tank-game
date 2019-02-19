using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using BTScriptableObject;

namespace Audio
{
    public enum AudioName
    {
        Fire, TankExplosion, EngineIdle, EngineDriving, ShellExplosion,
        Background
    }

    public class AudioManager : IAudio
    {
        private IGameManager gameManager;
        private AudioScriptable audioScriptable;

        private List<AudioData> audioData;

        public AudioManager()
        {
            if (gameManager == null)
                gameManager = StartService.Instance.GetService<IGameManager>();

            audioScriptable = Resources.Load<AudioScriptable>("AudioList");

            if (audioScriptable != null)
                audioData = audioScriptable.audioData;

            StartService.Instance.GetService<IBullet>().BulletSpawnEvent += PlayAudioOneShot;
            StartService.Instance.GetService<IEnemy>().DestroyEnemySoundFX += PlayAudioOneShot;
            Player.PlayerManager.Instance.playerDestroyedAudioEvent += PlayAudioOneShot;

            //PlayAudio(AudioName.Background);
        }

        public void OnUpdate()
        {

        }

        AudioClip ReturnAudio(AudioName audioName)
        {
            AudioClip audioClip = null;
            for (int i = 0; i < audioData.Count; i++)
            {
                if (audioName == audioData[i].audioName)
                {
                    audioClip = audioData[i].audioClip;
                    Debug.Log("[AudioManager]" + audioClip.name);
                    break;
                }
            }

            return audioClip;
        }

        public void PlayAudio(AudioName audioName)
        {
            StartService.Instance.bgSource.clip = ReturnAudio(audioName);
            if (StartService.Instance.bgSource.isPlaying == false)
                StartService.Instance.bgSource.Play(0);
        }

        public void PlayAudioOneShot(AudioName audioName)
        {
            StartService.Instance.fxSource.PlayOneShot(ReturnAudio(audioName));
        }

        public void StopFXAudio()
        {
            StartService.Instance.fxSource.Stop();
        }

        public void StopBackground()
        {
            StartService.Instance.bgSource.Stop();
        }
    }
}