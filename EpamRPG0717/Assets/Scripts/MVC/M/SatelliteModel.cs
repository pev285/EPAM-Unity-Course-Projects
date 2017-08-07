using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteModel : MonoBehaviour {

    [SerializeField]
    private float satelliteDistance;
    [SerializeField]
    private float satelliteHorDeviationAngle;
    [SerializeField]
    private float satelliteVertDeviationAngle;

    private float saveSatelliteDistance;
    private float saveSatelliteHorDeviationAngle;
    private float saveSatelliteVertDeviationAngle;


    [SerializeField]
    private float mouseWheelSpeed = 10.0f;
    [SerializeField]
    private float vertRotationSpeed = 2f; //0.5f;
    [SerializeField]
    private float horizRotationSpeed = 2f; //0.5f;



    [SerializeField]
    private float minSatelliteDistance = 0f;
    [SerializeField]
    private float defaultCameraDistance = 1.5f;
    [SerializeField]
    private float defaultVertDeviationAngle = 15f;
    [SerializeField]
    private float defaultHorDeviationAngle = 0f;




    [SerializeField]
    private bool relativePositionChangeMode = false;

///////////////////////

    private ControllerEventSystem controllerES;

    public void SetEventsSystem(ControllerEventSystem ces)
    {
        this.controllerES = ces;

        SubscribeOnKeyboardEvents();
    }
////////////////////


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

    public void SatelliteMovementOff() {
        relativePositionChangeMode = false;
    }


    private Vector3 savePosition;
    private Quaternion saveRotation;

    public void PrepareForFiringWeapon() {
        SaveSatelliteParameters();

        satelliteDistance = 0;
        satelliteHorDeviationAngle = 0;
        //satelliteVertDeviationAngle = 0;
    }

    public void AftreFiringTheWeapon() {
        new Timer(gameObject, () => {RestoreSatelliteParameters();}, 1f);

    }


    private void SaveSatelliteParameters() {
        saveSatelliteDistance = satelliteDistance;
        saveSatelliteHorDeviationAngle = satelliteHorDeviationAngle;
        saveSatelliteVertDeviationAngle = satelliteVertDeviationAngle;
    }
    private void RestoreSatelliteParameters() {
        satelliteDistance = saveSatelliteDistance;
        satelliteHorDeviationAngle = saveSatelliteHorDeviationAngle;
        satelliteVertDeviationAngle = saveSatelliteVertDeviationAngle;
    }


    ////////////////////////////////////////////////////////////
    // ###################################################### //
    ////////////////////////////////////////////////////////////


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



///////////////////////////////////////////////////////////////////////////////////////

// Use this for initialization
	void Start () {

	    SetSatelliteDefaults();

	}



    private void SubscribeOnKeyboardEvents() {


        controllerES.turnHorizontalEvent += TurnHorizontal;
        controllerES.turnVerticalEvent += TurnVertical;
        controllerES.changeCameraDistanceEvent += ChangeApproach;


        controllerES.prepareToFireEvent += PrepareForFiringWeapon;
        controllerES.fireEvent += AftreFiringTheWeapon;

        controllerES.startMoveCameraEvent += SatelliteMovementOn;
        controllerES.stopMoveCameraEvent += SatelliteMovementOff;
        controllerES.loadCameraDefaultsEvent += SetSatelliteDefaults;

    }




} // End Of Class //

