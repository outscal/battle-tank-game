using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class EnemyTankView : MonoBehaviour
{
    EnemyTankController _enemyTankController;
    public Rigidbody _rb;


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetController(EnemyTankController enemyTankController)
    {
        _enemyTankController = enemyTankController;
    }
}
