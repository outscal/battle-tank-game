using UnityEngine;

public class EnemyController
{
    private EnemyModel enemyModel;
    private EnemyView enemyView;
    private Rigidbody rb;
    
    public EnemyController(EnemyModel enemymodel, EnemyView enemyview, Transform spawnTransform)
    {
        this.enemyModel = enemymodel;
        enemyView = GameObject.Instantiate<EnemyView>(enemyview, spawnTransform.position,Quaternion.identity);
        rb = enemyView.GetComponent<Rigidbody>();
        this.enemyView.SetEnemyController(this);
        this.enemyModel.SetEnemyController(this);
    }
    public void Move()
    {
        var moveForward = enemyView.transform.forward * enemyModel.speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveForward);
    }
    public void Turn()
    {
        float turn = 1 * enemyModel.TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
    public EnemyModel GetEnemyModel()
    {
        return enemyModel;
    }
    public void Fire()
    {
        enemyView.bulletSpawner.SpawnBullet(enemyView.bulletSpawner.transform);
    }
    public void GetDamage(float damage)
    {
        enemyModel.Health -= damage;
        if(enemyModel.Health <= 0)
        {
            //tank destroy
        }
    }
}
