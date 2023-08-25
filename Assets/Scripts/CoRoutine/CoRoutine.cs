using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoRoutine : MonoBehaviour
{
    public EnemyServices enemyServices;
    public GameObject[] floor;
    [SerializeField]
    private float destroyDelay;
    [SerializeField]
    private List<GameObject> enemies;
    [SerializeField]
    private float Delay;
    // Start is called before the first frame update
    private IEnumerator Start()
    {
       yield return StartCoroutine(DestroyEnemies(Delay));
    
    }

    private IEnumerator DestroyFloor()
    {
        foreach (var gameobject in floor)
        {
            Debug.Log("Destroying GameObject" + gameobject.name);
            Destroy(gameobject);
            yield return new WaitForSeconds(destroyDelay);
        }
        yield return null;
    }
    private IEnumerator CoroutineNormal()
    {
        Debug.Log("gameobject");
        yield return null;  
    }
    private IEnumerator DestroyEnemies(float Delay) 
    {
        yield return new WaitForSeconds(Delay);
        enemies= enemyServices.GetEnemies();
        foreach (var gameobject in enemies)
        {
            Debug.Log("Destroying GameObject" + gameobject.name);
            EnemyView enemy=gameobject.GetComponent<EnemyView>();
            yield return StartCoroutine(enemy.Death());
            Destroy(gameobject);
            yield return new WaitForSeconds(destroyDelay);
        }
        yield return StartCoroutine (DestroyFloor());
    }
}
