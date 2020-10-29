using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnController : MonoSingletonGeneric<EnemySpawnController>
{
    [SerializeField]
    private GameObject basicEnemy;
    [SerializeField]
    private Button spawnButton;
    private int count;
    private bool noTank;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Invoke("SpawnEnemy", 2f);
        noTank = false;
        spawnButton.onClick.AddListener(SpawnEnemy);
    }
    private void SpawnEnemy() {
        if (transform.childCount==0)
        {
            if (count < 4)
            {
                GameObject enemy = Instantiate(basicEnemy, new Vector3(UnityEngine.Random.Range(-48,48), 0, UnityEngine.Random.Range(-48,47)), transform.rotation);
                Renderer[] rend = enemy.GetComponentsInChildren<Renderer>();
                enemy.transform.SetParent(transform);
                for (int i = 0; i < rend.Length; i++) rend[i].material.color = Color.red;
                enemy.tag="Enemy";
                count++;
            }
            else {
                GameObject enemy = Instantiate(basicEnemy, new Vector3(UnityEngine.Random.Range(-48, 48), 0, UnityEngine.Random.Range(-48, 47)), transform.rotation);
                Renderer[] rend = enemy.GetComponentsInChildren<Renderer>();
                enemy.transform.SetParent(transform);
                for (int i = 0; i < rend.Length; i++) rend[i].material.color = Color.black;
                enemy.transform.localScale *= 3f;
                enemy.tag ="BossEnemy";
                count = 0;
            }
        }
    }
    private void Wait() { }
    // Update is called once per frame
    void Update()
    {   
        

    }
}
