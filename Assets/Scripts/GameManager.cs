using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : GenericSingleton<GameManager>
{
    
    
    // public GameObject deathText;

    public void PlayerDeath()
    {
        // DeathText();
        Debug.Log("Hello");
        GameObject.FindGameObjectWithTag("Player").GetComponent<TankView>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyPatroling>().enabled = false;
        }
        StartCoroutine(CameraAnime());        
    }

    IEnumerator CameraAnime()
    {
        yield return new WaitForSeconds(2f);       
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-80.5f, 58.3f, -68.4f);
        GameObject.FindGameObjectWithTag("MainCamera").transform.rotation = Quaternion.Euler(21.609f, 52.41f, 0);
        StartCoroutine(EnemyAnime());
    }

    IEnumerator EnemyAnime()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            StartCoroutine(EnemyAnime());
        }
        StartCoroutine(OtherObjectsAnime());
    }

    IEnumerator OtherObjectsAnime()
    {
        yield return new WaitForSeconds(1f);
        if (GameObject.FindGameObjectWithTag("LevelArt") != null)
        {            
            Destroy(GameObject.FindGameObjectWithTag("LevelArt"));
            StartCoroutine(OtherObjectsAnime());
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }


    public void DeathText()
    {
        // deathText.gameObject.SetActive(true);
        // SceneController.Instance.StopAllSounds();
        // SceneController.Instance.StartSpecificSound(2);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            // deathText.GetComponent<TextMeshProUGUI>().text = "Congratulations, You won!";
            PlayerDeath();
        }
    }
}