using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteModel : MonoBehaviour {




    [SerializeField]
    private float satelliteDistance;

//    [SerializeField]
//    private Vector3 satelliteViewDirection;
    [SerializeField]
    private float satelliteHorDeviationAngle;
    [SerializeField]
    private float satelliteVertDeviationAngle;


    [SerializeField]
    private float mouseWheelSpeed = 3.0f;
    [SerializeField]
    private float vertRotationSpeed = 2f; //0.5f;
    [SerializeField]
    private float horizRotationSpeed = 2f; //0.5f;


    [SerializeField]
    private bool relativePositionChangeMode = false;

    private const float minSatelliteDistance = 1f;
    private const float defaultCameraDistance = 1.5f;
    private const float defaultVertDeviationAngle = 15f;
    private const float defaultHorDeviationAngle = 0f;





// ******************************************************************* //
    public void TurnHorizontal(float shift) {
        if (relativePositionChangeMode) {
            satelliteHorDeviationAngle -= horizRotationSpeed * shift * Time.deltaTime;
//            Quaternion quaternion = Quaternion.AngleAxis(horizRotationSpeed * shift * Time.deltaTime, Vector3.up);
//            satelliteViewDirection = quaternion * satelliteViewDirection;
        }
    }

    public void TurnVertical(float shift) {
        satelliteVertDeviationAngle -= vertRotationSpeed * shift * Time.deltaTime;
    }

    public void ChangeApproach(float shift) {
        satelliteDistance -= mouseWheelSpeed * shift * Time.deltaTime;
        if (satelliteDistance < minSatelliteDistance) {
            satelliteDistance = minSatelliteDistance;
        }
    }


    public void SetSatelliteDefaults() {
//    satelliteViewDirection = Vector3.forward; //targetObject.transform.forward;
    satelliteDistance = defaultCameraDistance;
    satelliteVertDeviationAngle = defaultVertDeviationAngle;
    satelliteHorDeviationAngle = defaultHorDeviationAngle;
    }




    public void SatelliteMovementOn() {
        relativePositionChangeMode = true;
    }

    ////////////////////////////////////////////////////////////
    // ###################################################### //
    ////////////////////////////////////////////////////////////
//
//    public Vector3 ViewDirection {
//        get {
//            return satelliteViewDirection;
//        }
//    }

    public float Distance {
        get {
            return satelliteDistance;
        }
    }

    public float VerticalDeviation {
        get {
            return satelliteVertDeviationAngle;
        }
    }

    public float HorizontalDeviation {
        get {
            return satelliteHorDeviationAngle;
        }
    }





// Use this for initialization
	void Start () {

	    SetSatelliteDefaults();

	}
	

}
