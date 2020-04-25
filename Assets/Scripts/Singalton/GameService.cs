using System.Collections.Generic;
using UnityEngine;
using Generic;

public class GameService : MonoSingletonGeneric<GameService>
{

    public List<GameObject> LevelArts;

    protected override void Awake()
    {
        base.Awake();
    }


    public void DestroyeAllGameArts()
    {
        for (int i = 0; i < LevelArts.Count; i++)
        {
            LevelArts[i].SetActive(false);
        }
    }

}
