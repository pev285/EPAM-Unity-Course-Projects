using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    private Vector3 cameraPos;

	// Use this for initialization
	void Start () {
        cameraPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        cameraPos.z += 3.0f*(Input.GetAxis("Mouse ScrollWheel"));

        if(cameraPos.z > -1f)
        {
            cameraPos.z = -1.0f;
        }
        transform.position = cameraPos;
    }
}
