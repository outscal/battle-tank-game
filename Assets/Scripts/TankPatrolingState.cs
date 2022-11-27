using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPatrolingState : TankState
{

    private float timeElapsed;

    // Update is called once per frame
    protected override void Awake()
    {
        base.Awake();
        Debug.Log("Petroling state");
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        Debug.Log("Entering State: Petroling");
        tankView.ChangeColor(color);
        
    }
    public override void OnEXitState()
    {
        base.OnEXitState();
        Debug.Log("Exiting State: Petroling");
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 5f)
        {
            tankView.ChangeState(tankView.chasingState);
        }
    }
}
