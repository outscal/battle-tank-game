using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingText : MonoBehaviour
{
    [Header("TEXT SETTINGS")]
    [SerializeField] [TextArea] private string[] itemInfo;
    [SerializeField] private float textSpeed = 0.05f;

    [Header("UI SETTINGS")]
    [SerializeField] Text info;
    private int currentDisplayingText = 0;

    public void Start()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        for(int i = 0; i < itemInfo[currentDisplayingText].Length + 1; i++)
        {
            info.text = itemInfo[currentDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
