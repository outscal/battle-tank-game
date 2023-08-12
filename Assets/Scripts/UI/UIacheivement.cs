using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIacheivement : MonoBehaviour
{
    public Vector2 defaultPositon;
    public Color defaultColor;
    public float animationSpeed;
    public bool playAnimation = false;
    private TMP_Text acheivementText;

    private void Awake()
    {
        defaultPositon = GetComponent<RectTransform>().anchoredPosition;
        acheivementText = GetComponent<TMP_Text>();
        defaultColor = GetComponent<TMP_Text>().color;
    }
    public void Start()
    { 
        AcheivementService.Instance.onBulletAcheivement += playAcheivementAnimation;
        AcheivementService.Instance.onDistanceAcheivement += playAcheivementAnimation;
        AcheivementService.Instance.onKillingAcheivement += playAcheivementAnimation;
        gameObject.SetActive(false);
    }

    private void playAcheivementAnimation(string message)
    {
        acheivementText.text = message;
        resetText();
        playAnimation = true;
    }

    private void resetText()
    {
        GetComponent<RectTransform>().anchoredPosition = defaultPositon;
        acheivementText.color = defaultColor;
    }

    private void Update()
    {
        moveupAnimation();
    }

    private void moveupAnimation()
    {
        if (playAnimation)
        {
            if (GetComponent<RectTransform>().anchoredPosition.y >= 0f)
            {
                playAnimation = false;
                gameObject.SetActive(false);
                resetText();
            }
            transform.localPosition += Vector3.up * 40f * Time.deltaTime * animationSpeed;
            acheivementText.color -= new Color(0, 0, 0, Time.deltaTime / animationSpeed);
            new WaitForSeconds(0.2f);
        }
    }
}
