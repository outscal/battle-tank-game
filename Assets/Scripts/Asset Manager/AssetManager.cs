using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetManager : SingletonGeneric<AssetManager>
{
    public GameObject LevelPrefab;
    public List<EnemyView> EnemyViews { get { return m_EnemyViews; } }
    public TankView TankView { get { return m_TankView; } }
    public GameObject Level { get { return m_Level; } }
    public ShellService ShellService { get { return m_ShellService; } }

    private GameObject m_Level;
    private TankView m_TankView;
    private ShellService m_ShellService;
    private List<EnemyView> m_EnemyViews = new List<EnemyView>();

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
    public void SetShellService(ShellService shellService) => m_ShellService = shellService;

    private void Start()
    {
        m_Level = Instantiate(LevelPrefab) as GameObject;
    }

    public void ClearLevel()
    {
        // Destroy Tank
        StartCoroutine(DestroyTank());

        // Destroy Enemies
        StartCoroutine(DestroyEnemies());

        // Disable Level
        StartCoroutine(DestroyLevel());

        return;
    }

    private IEnumerator DestroyLevel()
    {
        yield return new WaitForSeconds(2);
        if (m_Level)
        {
            Destroy(m_Level);
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
            m_TankView.DestroyTank();
            m_TankView = null;
        }
    }
}