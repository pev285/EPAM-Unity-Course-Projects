using System;
using UnityEngine;

public class CharacterCameraRepresentation : MonoBehaviour {

    //[SerializeField]
    private GameObject playerCamera;
    SatelliteModel cameraModel;

    [SerializeField]
    private GameObject targetObject;



// Use this for initialization
	void Start () {
		playerCamera = gameObject;
        cameraModel = playerCamera.GetComponent<SatelliteModel>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float cameraHorizDeviationAngle = cameraModel.HorizontalDeviation;
        float cameraVertDeviationAngle = cameraModel.VerticalDeviation;
        float player2cameraDistance = cameraModel.Distance;

        MoveCamera(cameraHorizDeviationAngle, cameraVertDeviationAngle, player2cameraDistance);

	}


    private void MoveCamera(float cameraHorizDeviationAngle, float cameraVertDeviationAngle, float player2cameraDistance) {

        Vector3 cameraViewHorizontalDirection = targetObject.transform.forward;
        Quaternion quaternion = Quaternion.AngleAxis(cameraHorizDeviationAngle, Vector3.up);
        cameraViewHorizontalDirection = quaternion * cameraViewHorizontalDirection;


        Vector3 cameraRight = Quaternion.AngleAxis(90f, Vector3.up) * cameraViewHorizontalDirection;
        Quaternion cameraVerticalRotation = Quaternion.AngleAxis(cameraVertDeviationAngle, cameraRight);
        Vector3 newCameraPosition = cameraVerticalRotation * (-cameraViewHorizontalDirection) * player2cameraDistance;

        Vector3 relativePosition = targetObject.transform.position - playerCamera.transform.position;

        playerCamera.transform.position = targetObject.transform.position + newCameraPosition;

        playerCamera.transform.rotation = Quaternion.LookRotation(relativePosition);
    }
}
