using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager> 
{
    [SerializeField] private float destructionSpeed;
    [SerializeField] private GameObject gameWorld;
    [SerializeField] Transform[] childrenView;
    private Coroutine destructionCoroutine;

    public void destroyWorld()
    {
        destructionCoroutine = StartCoroutine(checkAndDestroy());
    }

    private IEnumerator checkAndDestroy()
    {
        yield return TankService.Instance.destroyAll;
        yield return destroyChildObjects(gameWorld);
    }


    private IEnumerator destroyChildObjects(GameObject _gameObject)
    {
        if (_gameObject.GetComponentInChildren<Transform>() != null)
        {
            Debug.Log("reading world destruction");
            Transform[] children = _gameObject.GetComponentsInChildren<Transform>();
            childrenView = children;
            for(int i=children.Length-1; i>=0;i--)
            {
                yield return destroyObject(children[i].gameObject);
            }
        }
    }

    private IEnumerator destroyObject(GameObject _gameObject )
    {
        yield return new WaitForSeconds(destructionSpeed);
        Debug.Log("deleted" + _gameObject.name);
        Destroy(_gameObject);
    }

}
