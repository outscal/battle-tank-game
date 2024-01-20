using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScripts : MonoBehaviour
{
    [SerializeField] private Slider loader;
    [SerializeField] private TMP_Text loadingPer;
    float loadingProgress = 0;

    public void playLevel()
    {
        Debug.Log(Application.backgroundLoadingPriority);
        Application.backgroundLoadingPriority = ThreadPriority.High;
        StartCoroutine(loadPlaylevel());
    }

    private IEnumerator loadPlaylevel ()
    {
        AsyncOperation playLevelProgress = SceneManager.LoadSceneAsync(1);
        while(!playLevelProgress.isDone)
        {
            loadingProgress = playLevelProgress.progress / 0.9f;
            loader.value= loadingProgress;
            loadingPer.text = (loadingProgress * 100).ToString();
            Debug.Log("Loading progress: "+loadingProgress);
            yield return null;
        }
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        Application.backgroundLoadingPriority = ThreadPriority.Low;
    }
}
