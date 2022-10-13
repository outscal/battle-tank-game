using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] List<MeshRenderer> meshRenderers = new List<MeshRenderer>();
    MeshFilter meshFilter;
    List<Vector3> triangle = new List<Vector3>(3);

    private EnemyController enemyController;
    WaitForSeconds WaitBeforeDestroy = new WaitForSeconds(4f);


    public void LinkController(EnemyController _enemyController)
    {
        enemyController = _enemyController;
    }

    private void Update()
    {
        enemyController.Patrol(this.gameObject.transform.position);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<BulletView>() != null)
        {
            enemyController.DisableEnemy(meshRenderers);
            StartCoroutine(DestroyAfterWait());
        }
    }
    IEnumerator DestroyAfterWait()
    {
        yield return WaitBeforeDestroy;
        enemyController.DestroyEnemy();
    }

}
