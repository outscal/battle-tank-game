using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DestroySequence : Singleton<DestroySequence>
{
    [SerializeField] private GameObject levelArt;
    [SerializeField] private GameObject exitPanel;
    [SerializeField] private GameObject cam;
    private bool PlayerWon = false;
    //private int countChild;
    //private List<Transform> levelObjs;
    //private void Start()
    //{
    //    countChild = levelArt.transform.childCount;
    //    if (countChild != 0)
    //    {
    //        for(int i = 0; i < countChild - 1; i++)
    //        {
    //            levelObjs.Add(levelArt.transform.GetChild(i));
    //        }
    //    }
    //}
    public void PlayerDeath()
    {
        StartCoroutine(CameraView());
        exitPanel.gameObject.SetActive(true);        
    }
    public void WaveComplete(Transform Player) // level Complition check
    {
        Destroy(Player.gameObject, 1f);
        StartCoroutine(CameraView());
        exitPanel.gameObject.SetActive(true);
    }

    IEnumerator CameraView()
    {
        yield return new WaitForSeconds(1f);       
        cam.transform.position = new Vector3(-80f, 50f, -60f);
        cam.transform.rotation = Quaternion.Euler(20f, 50f, 0);
        if (!PlayerWon) 
        {
            StartCoroutine(EnemyDeath()); 
        }
        else
        {
            StartCoroutine(destroySurrounding());
        }
        
    }

    IEnumerator EnemyDeath()
    {   var EnemyObjs = FindObjectsOfType<EnemyView>();
        int countEnemy = EnemyObjs.Length;
        while (countEnemy > 0)
        {
            yield return new WaitForSeconds(1f);
            Destroy(EnemyObjs[countEnemy -= 1].gameObject.transform);
        }
        StartCoroutine(destroySurrounding());
    }

    IEnumerator destroySurrounding()
    {
        while(levelArt.transform.childCount > 0)
        {
            yield return new WaitForSeconds(1f);
            var temp = levelArt.transform.GetChild(0);
            while (temp.transform.childCount != 0)
            {
                Destroy(temp.transform.GetChild(0).gameObject);
                yield return new WaitForSeconds(1f);
            }
            //levelObjs.RemoveAt(countChild - 1);
            Destroy(temp.gameObject);
        }
        Destroy(levelArt,1f);
    }
    public void DeathText()
    {
        if (PlayerWon)
        {
            exitPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Congratulations, You won!";
        }
        else
        {
            exitPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Too Bad, You lost!";
        }
    }
}
