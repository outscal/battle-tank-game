using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    public InputField setNormalTanks, setMediumTanks, setHardTanks;
    public GameObject settingsPanel;
    public Text dialogText;
    void Start()
    {
    }

    public void SubmitData() 
    {

        if (int.Parse(setNormalTanks.text) + int.Parse(setMediumTanks.text) + int.Parse(setHardTanks.text) <= 20 && int.Parse(setNormalTanks.text) + int.Parse(setMediumTanks.text) + int.Parse(setHardTanks.text) > 0) 
        {
            PlayerPrefs.SetInt("normalTanks", int.Parse(setNormalTanks.text));
            PlayerPrefs.SetInt("mediumTanks", int.Parse(setMediumTanks.text));
            PlayerPrefs.SetInt("hardTanks", int.Parse(setHardTanks.text));
            settingsPanel.SetActive(false);

        }
        if (int.Parse(setNormalTanks.text) + int.Parse(setMediumTanks.text) + int.Parse(setHardTanks.text) > 20 || int.Parse(setNormalTanks.text) + int.Parse(setMediumTanks.text) + int.Parse(setHardTanks.text) < 0) 
        {
            dialogText.text = "TANKS PER ROUND \r\n Please enter valid number";
        }

    }

    public void Settings() 
    {
        settingsPanel.SetActive(true);
        setNormalTanks.text = "3";
        setMediumTanks.text = "3";
        setHardTanks.text = "3";
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
