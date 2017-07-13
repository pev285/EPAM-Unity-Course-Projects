using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer  {

    TimerComponent tc;

    public Timer(GameObject go, UnityAction action, float time, int repetitions)
    {
        tc = go.AddComponent<TimerComponent>();

        tc.Action = action;
        tc.TimeToWait = time;
        tc.RepetitionsNumber = repetitions;
    }


    public void StopTimer()
    {
        tc.TimeToWait = 100000;
        tc.RepetitionsNumber = 0;
    }

}
