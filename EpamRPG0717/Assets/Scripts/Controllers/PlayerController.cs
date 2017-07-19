using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private GameObject playerCamera;

    private GameObject headTop;
    private Vector3 playerDirection;

    private float player2cameraDistance;

    private Vector3 player2cameraDirection;

	// Use this for initialization
	void Start () {

        headTop = GameObject.Find("HeadTop");
        playerCamera = GameObject.Find("PlayerCamera");

        playerDirection = transform.forward;

        player2cameraDirection = playerCamera.transform.position - headTop.transform.position;

        player2cameraDistance = player2cameraDirection.magnitude;

        player2cameraDirection = player2cameraDirection.normalized;




//        Animation anim = GetComponent<Animation>();
//
//        anim["Walk"].enabled = true;
	}



	// Update is called once per frame
	void Update () {
		
	}




    void FixedUpdate() {

    }




} // End Of Class //


