using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private Transform[] m_SpawnPoints;                         
    [SerializeField]private GameObject m_EnemyPrefab;                          

    private void Start() {
        foreach(var _location in m_SpawnPoints){
            Instantiate(m_EnemyPrefab,_location);
        }
    } 
}
