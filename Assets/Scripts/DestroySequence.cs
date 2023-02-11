using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DestroySequence : Singleton<DestroySequence>
{
    public GameObject levelArt;
    //private List<Transform> levelObjs;
    public GameObject exitPanel;
    public GameObject cam;
    public void PlayerDeath()
    {
        
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyView>().enabled = false;
        }
        StartCoroutine(CameraView());
        exitPanel.gameObject.SetActive(true);        
    }

    IEnumerator CameraView()
    {
        yield return new WaitForSeconds(1f);       
        cam.transform.position = new Vector3(-80f, 50f, -60f);
        cam.transform.rotation = Quaternion.Euler(20f, 50f, 0);
        StartCoroutine(EnemyDeath());
    }

    IEnumerator EnemyDeath()
    {
        yield return new WaitForSeconds(2f);
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            StartCoroutine(EnemyDeath());
        }
        StartCoroutine(destroySurrounding());
    }

    IEnumerator destroySurrounding()
    {
        
        yield return new WaitForSeconds(1f);
        if (!levelArt.transform.GetChild(0))
        {   
            //var temp = levelObjs[i];
            //levelObjs.RemoveAt(i);   
            Destroy(levelArt.transform.GetChild(0));
            //Destroy(temp.gameObject);
            StartCoroutine(destroySurrounding());
        }
    }
}
