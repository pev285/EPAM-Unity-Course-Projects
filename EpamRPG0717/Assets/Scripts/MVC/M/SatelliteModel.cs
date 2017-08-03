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
    private float mouseWheelSpeed = 10.0f;
    [SerializeField]
    private float vertRotationSpeed = 2f; //0.5f;
    [SerializeField]
    private float horizRotationSpeed = 2f; //0.5f;



    private const float minSatelliteDistance = 1f;
    private const float defaultCameraDistance = 20f;//1.5f;
    private const float defaultVertDeviationAngle = 15f;
    private const float defaultHorDeviationAngle = 0f;



    private KeyBinder gameModeKeyBinder;

    [SerializeField]
    private bool relativePositionChangeMode = false;

// ******************************************************************* //
    public void TurnHorizontal(float shift) {
        if (relativePositionChangeMode) {
            satelliteHorDeviationAngle += horizRotationSpeed * shift; // * Time.deltaTime;
        }
    }

    public void TurnVertical(float shift) {
        satelliteVertDeviationAngle -= vertRotationSpeed * shift;// * Time.deltaTime;
    }

    public void ChangeApproach(float shift) {
        satelliteDistance -= mouseWheelSpeed * shift;// * Time.deltaTime;
        if (satelliteDistance < minSatelliteDistance) {
            satelliteDistance = minSatelliteDistance;
        }
    }


    public void SetSatelliteDefaults() {
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

        SubscribeOnKeyboardEvents();

	}

    private void SubscribeOnKeyboardEvents() {
        gameModeKeyBinder = GameManager.Instance.GameModeKeyBinder;

        gameModeKeyBinder.StartListening(KeyboardEventType.StopCharRotation, delegate  {
            relativePositionChangeMode = true;
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.ResumeCharRotation, delegate  {
            relativePositionChangeMode = false;
        });


        gameModeKeyBinder.StartListening(KeyboardEventType.TurnRight, delegate  {
            TurnHorizontal(Input.GetAxis("Mouse X"));
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.TurnLeft, delegate  {
            TurnHorizontal(Input.GetAxis("Mouse X"));
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.TurnUp, delegate  {
            TurnVertical(Input.GetAxis("Mouse Y"));
//            satelliteVertDeviationAngle -= vertRotationSpeed * Input.GetAxis("Mouse Y");
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.TurnDown, delegate  {
            TurnVertical(Input.GetAxis("Mouse Y"));
        });

        gameModeKeyBinder.StartListening(KeyboardEventType.CameraMoveNear, delegate  {
            ChangeApproach(Input.GetAxis("Mouse ScrollWheel"));
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.CameraMoveAway, delegate  {
            ChangeApproach(Input.GetAxis("Mouse ScrollWheel"));
        });

//        CameraFixDistance,
//        StopHorizontalMouseMotion,
//        StopVerticalMouseMotion,


        gameModeKeyBinder.StartListening(KeyboardEventType.CameraDefaults, delegate  {
            SetSatelliteDefaults();
        });

    }
	

}
