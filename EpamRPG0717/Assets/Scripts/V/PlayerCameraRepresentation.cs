using System;
using UnityEngine;

public class PlayerCameraRepresentation : MonoBehaviour {

    //[SerializeField]
    private GameObject playerCamera;
    PlayerCameraModel cameraModel;



// Use this for initialization
	void Start () {
		playerCamera = gameObject;
        cameraModel = playerCamera.GetComponent<PlayerCameraModel>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
