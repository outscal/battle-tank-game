using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : SingletonGeneric<AssetManager>
{
    public GameObject LevelPrefab;

    private GameObject m_Level;
    private TankView m_TankView;
    private List<EnemyView> m_EnemyViews = new List<EnemyView>();

    public List<EnemyView> GetEnemyViews() { return m_EnemyViews; }
    public TankView GetTankView() { return m_TankView; }
    public GameObject GetLevel() { return m_Level; }

    public void AddEnemyView(EnemyView enemyView)
    {
        if(!m_EnemyViews.Contains(enemyView))
            m_EnemyViews.Add(enemyView); 
    }
    public void RemoveEnemyView(EnemyView enemyView)
    {
        if(m_EnemyViews.Contains(enemyView))
            m_EnemyViews.Remove(enemyView); 
    }
    public void SetTankView(TankView tankView) => m_TankView = tankView;

    private void Start()
    {
        m_Level = Instantiate(LevelPrefab) as GameObject;
    }

    public IEnumerator ClearLevel()
    {
        // Destroy Tank
        StartCoroutine(DestroyTank());

        // Destroy Enemies
        StartCoroutine(DestroyEnemies());

        // Disable Level
        StartCoroutine(DestroyLevel());

        yield return null;
    }

    private IEnumerator DestroyLevel()
    {
        yield return new WaitForSeconds(2);
        if (m_Level)
        {
            Destroy(m_Level.gameObject);
            m_Level = null;
        }
    }
    private IEnumerator DestroyEnemies()
    {
        yield return new WaitForSeconds(1);

        int enemiesCount = m_EnemyViews.Count;
        for (int i = enemiesCount - 1; i >= 0; i--)
        {
            EnemyView enemyView = m_EnemyViews[i];
            if (enemyView)
            {
                enemyView.DestroyEnemy();
            }
        }
    }
    private IEnumerator DestroyTank()
    {
        yield return new WaitForSeconds(0);
        if (m_TankView)
        {
            Destroy(m_TankView.gameObject);
            m_TankView = null;
        }
    }
}