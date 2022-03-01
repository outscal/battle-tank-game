using System;
using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHelathBar : MonoBehaviour
{
    [SerializeField] private Image healthBarPrefab;
    [SerializeField] private RectTransform healthBarsContainer;
    
    

    private int _lifeIndex;
    private enum Colors
    {
        Green = 66,
        Orange = 50,
        Red = 25
    }

    private void OnDisable()
    {
        if (PlayerTankService.Instance.Player!=null)
        {
            PlayerTankService.Instance.Player.DecreaseHealth -= UpdateHealth;
            PlayerTankService.Instance.Player.LoseLife -= LoseLife;
        }
    }

    private List<Image> _healthBars = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        PlayerTankService.Instance.Player.DecreaseHealth += UpdateHealth;
        PlayerTankService.Instance.Player.LoseLife += LoseLife;
        _lifeIndex = ((PlayerTankModel) PlayerTankService.Instance.Player.TankModel).Lives;
        for (int i = 0; i < _lifeIndex; i++)
        {
            Image healthBar =Instantiate(healthBarPrefab, healthBarsContainer);
            healthBar.color = Color.green;
            _healthBars.Add(healthBar);
        }
    }

    private void UpdateHealth(float newFill)
    {
        Image healthB = _healthBars[_lifeIndex-1];
        healthB.fillAmount = newFill;
        Debug.Log("Fill "+healthB.fillAmount);
        int fill =(int)(healthB.fillAmount * 100);
        healthB.color = (fill > ((int) Colors.Green)) ? Color.green : (fill > ((int) Colors.Orange)) ? Color.yellow : Color.red;

    }

    private void LoseLife()
    {
        _lifeIndex--;
        if (_lifeIndex < 1) _lifeIndex = 1;
    }
}
