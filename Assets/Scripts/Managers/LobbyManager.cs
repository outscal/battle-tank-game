using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public InputField setNormalTanks, setMediumTanks, setHardTanks;
    public GameObject settingsPanel;

    void Start()
    {
    }

    public void SubmitData() 
    {
        PlayerPrefs.SetInt("normalTanks", int.Parse(setNormalTanks.text));
        PlayerPrefs.SetInt("mediumTanks", int.Parse(setMediumTanks.text));
        PlayerPrefs.SetInt("hardTanks", int.Parse(setHardTanks.text));
        settingsPanel.SetActive(false);
    }

    public void Settings() 
    {
        settingsPanel.SetActive(true);
        setNormalTanks.text = "1";
        setMediumTanks.text = "1";
        setHardTanks.text = "1";
    }
    public void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
