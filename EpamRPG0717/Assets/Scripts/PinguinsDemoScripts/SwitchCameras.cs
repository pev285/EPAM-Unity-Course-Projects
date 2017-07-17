using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour {

    private Camera came;

	// Use this for initialization
	void Start () {

        came = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            came.enabled = !came.enabled;
        }

	}
}
