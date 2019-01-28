using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour {

    private bool move = false;

	public void SetPosition(Vector3 _position)
	{
        transform.position = _position;
	}


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

        }

    }

    IEnumerator MoveObj(bool _move)
    {
        move = _move;

        while (move == true)
        {



        }

        return null;
    }

    IEnumerator StopObj(bool _move)
    {
        move = _move;
        return null;
    }

}

	