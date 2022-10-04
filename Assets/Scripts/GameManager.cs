using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public bool startDestroying = false ;
    WaitForSeconds waitForDestroy = new WaitForSeconds(4f);
    bool playerDestroy=true;
    [SerializeField] List<GameObject> gameObjects = new List<GameObject>();
    void Update()
    {
        if(startDestroying && playerDestroy)
        {
            playerDestroy= false;
            StartCoroutine(DeleteAllGameObjects());
        }
    }

    private IEnumerator DeleteAllGameObjects() //cinematic destruction of the GameObjects after player death
    {
        for(int i=0;i<gameObjects.Count;i++)
        {
            gameObjects[i].GetComponent<MeshRenderer>().enabled = false;
            if(gameObjects[i].GetComponent<ParticleSystem>()!=null)
                gameObjects[i].GetComponent<ParticleSystem>().Play();
            yield return waitForDestroy;
            GameObject.Destroy(gameObjects[i]);

        }
    }

}
