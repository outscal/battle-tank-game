using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHelathBar : MonoBehaviour
{
    private enum Colors
     {
         Green = 66,
         Orange = 50,
         Red = 25
     }
    
    #region Serialized Data members

    [SerializeField] private Image healthBarPrefab;
    [SerializeField] private RectTransform healthBarsContainer;

    #endregion

    #region Private Data Members

    private int _lifeIndex;
    private List<Image> _healthBars = new List<Image>();

    #endregion

    #region Unity Functions

    private void OnDisable()
    {
        if (Tank.PlayerTankService.Instance.Player!=null)
        {
            Tank.PlayerTankService.Instance.Player.DecreaseHealth -= UpdateHealth;
            Tank.PlayerTankService.Instance.Player.LoseLife -= LoseLife;
        }
    }

    void Start()
    {
        Tank.PlayerTankService.Instance.Player.DecreaseHealth += UpdateHealth;
        Tank.PlayerTankService.Instance.Player.LoseLife += LoseLife;
        _lifeIndex = ((Tank.PlayerTankModel) Tank.PlayerTankService.Instance.Player.TankModel).Lives;
        for (int i = 0; i < _lifeIndex; i++)
        {
            Image healthBar =Instantiate(healthBarPrefab, healthBarsContainer);
            healthBar.color = Color.green;
            _healthBars.Add(healthBar);
        }
    }

    #endregion

    #region Private Functions

    private void LoseLife()
    {
        _lifeIndex--;
        if (_lifeIndex < 1) _lifeIndex = 1;
    }
    private void UpdateHealth(float newFill)
    {
        Image healthB = _healthBars[_lifeIndex-1];
        healthB.fillAmount = newFill;
        Debug.Log("Fill "+healthB.fillAmount);
        int fill =(int)(healthB.fillAmount * 100);
        healthB.color = (fill > ((int) Colors.Green)) ? Color.green : (fill > ((int) Colors.Orange)) ? Color.yellow : Color.red;

    }

    #endregion
}
