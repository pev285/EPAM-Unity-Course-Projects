using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScript : MonoBehaviour {

    public GameObject someGmaeObject;

    private float stopTime;
    private Timer timer;

	// Use this for initialization
	void Start () {

        Timer t = new Timer(someGmaeObject, delegate ()
        {
            print("AAA:" + Time.time);
        }, 1f, 3);

        timer = new Timer(someGmaeObject, Move, 1f, 100);

        stopTime = Time.time + 10f;
	}

    private void Move()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(pos.x + 1, pos.y + 1, pos.z + 1);
    }

    private void StopTimer()
    {
        timer.StopTimer();
    }


    // Update is called once per frame
    void Update () {
		if (stopTime <= Time.time)
        {
            StopTimer();
        }
	}
}
