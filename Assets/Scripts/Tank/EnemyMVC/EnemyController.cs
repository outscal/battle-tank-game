using UnityEngine;

public class EnemyController
{
    EnemyView enemyView;
    EnemyModel enemyModel;
    Vector3 leftPatrol;
    Vector3 rightPatrol;

    enum patrolDirection{
        left,
        right
    }

    patrolDirection currDir= patrolDirection.right ;

    public EnemyController(Vector3 spawnPoint,EnemyView _enemyView, EnemyModel _enemyModel)
    {
        enemyView = _enemyView;
        Vector3 tempPos = enemyView.gameObject.transform.position;
        leftPatrol = new Vector3(0,0, tempPos.z - _enemyModel.PatrolDistance);
        rightPatrol = new Vector3(0, 0, tempPos.z + _enemyModel.PatrolDistance);
        enemyView = GameObject.Instantiate<EnemyView>(_enemyView, spawnPoint, Quaternion.identity);
        enemyModel= _enemyModel;
        enemyView.LinkController(this);
    }


    public void Patrol(Vector3 currPos)
    {
        if(currDir==patrolDirection.left && currPos.z<leftPatrol.z)
        {
            currDir = patrolDirection.right;
            enemyView.gameObject.transform.forward *= -1;
        }
        else if(currDir==patrolDirection.right && currPos.z>rightPatrol.z)
        {
            currDir=patrolDirection.left;
            enemyView.gameObject.transform.forward *= -1;
        }
        if (currDir == patrolDirection.left)
            enemyView.gameObject.transform.position -= new Vector3(0,0,enemyModel.EnemySpeed * Time.deltaTime);
        else if(currDir== patrolDirection.right)
            enemyView.gameObject.transform.position += new Vector3(0, 0, enemyModel.EnemySpeed * Time.deltaTime);
    }

}
