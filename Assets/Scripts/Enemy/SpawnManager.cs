using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnnPosition;
    public GameObject[] enemyObject;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < enemyObject.Length; i++)
        {
            Instantiate(enemyObject[(Random.Range(0, enemyObject.Length))], spawnnPosition[i].position, Quaternion.identity);
        }
    }
}