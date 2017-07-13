using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour {

    private UnityAction action;
    private float timeSpan;
    private float timeVar;
    private int repetitionsNumber;

    public int RepetitionsNumber
    {
        get
        {
            return RepetitionsNumber;
        }
        set
        {
            RepetitionsNumber = value;
        }
    }


    public UnityAction Action
    {
        get
        {
            return action;
        }

        set
        {
            action = value;
        }
    }

    public float TimeToWait
    {
        get
        {
            return timeSpan;
        }

        set
        {
            timeVar = value;
            timeSpan = value;
        }
    }



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (repetitionsNumber == 0)
        {
            Destroy(this);
        }
        else
        {
            timeVar -= Time.deltaTime;

            if (timeVar <= 0)
            {
                action();
                repetitionsNumber--;
                timeVar = timeSpan;
            }
        }

	}
}
