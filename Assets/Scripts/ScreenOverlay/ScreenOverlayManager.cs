using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TankBattle.Tank;

public class ScreenOverlayManager : GenericMonoSingleton<ScreenOverlayManager>
{
    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Slider tankHealthBar;
    private TankController playerTankController;

    public void SetPlayerTankController(TankController _controller)
    {
        playerTankController = _controller;
        UpdateUIHealthBar();
        UpdateUIScore();
    }

    public void UpdateUIHealthBar()
    {
        tankHealthBar.value = playerTankController.GetTankHealth();
    }

    public void UpdateUIScore()
    {
        scoreText.text = "Score: " + (playerTankController.GetTankKills() * 10);
    }
}
