using System;
using UnityEngine;

public class CharacterCameraMover : MonoBehaviour {

    //[SerializeField]
    private GameObject playerCamera;
    SatelliteModel cameraModel;

    //[SerializeField]
    private GameObject viewTargetObject;
    public GameObject ViewTargetObject {
        set {
            viewTargetObject = value;
        }
    }

    private GameObject playerFace;
    public GameObject PlayerFace{
        set {
            playerFace = value;
        }
    }



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

        Vector3 cameraViewHorizontalDirection = viewTargetObject.transform.forward;

        Quaternion cameraRotation =  viewTargetObject.transform.rotation;
        cameraRotation = Quaternion.AngleAxis(cameraVertDeviationAngle, viewTargetObject.transform.right) * cameraRotation;
//        cameraRotation = cameraRotation * Quaternion.AngleAxis(cameraVertDeviationAngle, targetObject.transform.right);
        cameraRotation = Quaternion.AngleAxis(cameraHorizDeviationAngle, Vector3.up ) * cameraRotation;
//        cameraRotation = cameraRotation * Quaternion.AngleAxis(cameraHorizDeviationAngle, Vector3.up );
        playerCamera.transform.rotation = cameraRotation;

        playerCamera.transform.position = viewTargetObject.transform.position - playerCamera.transform.forward.normalized * player2cameraDistance;
/*
        Quaternion quaternion = Quaternion.AngleAxis(cameraHorizDeviationAngle, Vector3.up);
        cameraViewHorizontalDirection = quaternion * cameraViewHorizontalDirection;
//        rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(horizontalRotation, Vector3.up ));

        Vector3 cameraRight = Quaternion.AngleAxis(90f, Vector3.up) * cameraViewHorizontalDirection;
        Quaternion cameraVerticalRotation = Quaternion.AngleAxis(cameraVertDeviationAngle, cameraRight);

        Vector3 newCameraPosition = cameraVerticalRotation * (-cameraViewHorizontalDirection) * player2cameraDistance;

        Vector3 relativePosition = targetObject.transform.position - playerCamera.transform.position;

        playerCamera.transform.position = targetObject.transform.position + newCameraPosition;

        playerCamera.transform.rotation = Quaternion.LookRotation(relativePosition);
  */
    }
}
