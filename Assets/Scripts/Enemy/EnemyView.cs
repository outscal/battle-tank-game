using System;
using UnityEngine;


public class EnemyView : MonoBehaviour
{
   
    private new Renderer renderer;
    public EnemyController enemyController;
    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }


    public void FixedUpdate()
    {
        enemyController?.MoveTowardsPlayer();
    }

    public void UpdateColor(Color color)
    {
        renderer.material.color = color;
    }


}



