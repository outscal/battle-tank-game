using System.Collections;
using UnityEngine;


public class WaitForSecondsAsync : CustomYieldInstruction
{
    private readonly float _seconds;
    private float _startTime;

    public WaitForSecondsAsync(float seconds)
    {
        _seconds = seconds;
    }

    public override bool keepWaiting
    {
        get
        {
            if (_startTime == 0)
                _startTime = Time.realtimeSinceStartup;
            return Time.realtimeSinceStartup < _startTime + _seconds;
        }
    }
}

