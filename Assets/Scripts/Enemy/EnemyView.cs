using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private NavMeshAgent enemy;
    public Transform PlayerTankTarget;
    private new Renderer renderer;
    private EnemyController enemyController;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        enemy = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        enemy.SetDestination(PlayerTankTarget.position);
    }

    public void UpdateColor(Color color)
    {
        renderer.material.color = color;
    }

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }
}
