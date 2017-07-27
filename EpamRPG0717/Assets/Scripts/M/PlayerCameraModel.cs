using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraModel : MonoBehaviour {

	[SerializeField]
    private GameObject headTop;

    [SerializeField]
    private float player2cameraDistance;

    [SerializeField]
    private Vector3 cameraDirection;
    [SerializeField]
    private float cameraHorRotation;
    [SerializeField]
    private float cameraVertRotation;

    private const float minCameraDistance = 1f;
    private const float defaultCameraDistance = 1.5f;
    private const float defaultVertRotation = 25f;
    private const float defaultHorRotation = 0f;



    private void SetCameraDefaults() {
        cameraDirection = headTop.transform.forward;
        player2cameraDistance = defaultCameraDistance;
        cameraVertRotation = defaultVertRotation;
        cameraHorRotation = defaultHorRotation;
    }



    /////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////


// Use this for initialization
	void Start () {
	    SetCameraDefaults();


	}
	
	// Update is called once per frame
	void Update () {



	}

}
