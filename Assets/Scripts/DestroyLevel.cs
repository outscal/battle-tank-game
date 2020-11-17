using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    Coroutine coroutine=null;
    internal void CleanSlate(){
        if(coroutine==null){
            StartCoroutine(destroyLevelTerrain());
        }
    }

    IEnumerator destroyLevelTerrain(){
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        coroutine=null;
    }
}
