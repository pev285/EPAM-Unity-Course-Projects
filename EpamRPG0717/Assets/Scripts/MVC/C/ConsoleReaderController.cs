using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleReaderController : MonoBehaviour {

    private ControllerEventSystem inputES;

    public void SetControllerEventSystem(ControllerEventSystem ces)
    {
        inputES = ces;

        if (inputES == null) {
            print("SetControllerEventSystem: NULL parameter");
        }
    }




	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown(KeyCode.W))
        {
            inputES.InvokeStartForwardEvent();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            inputES.InvokeStopForwardEvent();
        }

		if (Input.GetKeyDown(KeyCode.S))
        {
            inputES.InvokeStartBackEvent();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            inputES.InvokeStopBackEvent();
        }

		if (Input.GetKeyDown(KeyCode.A))
        {
            inputES.InvokeStartLeftEvent();
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            inputES.InvokeStopLeftEvent();
        }

		if (Input.GetKeyDown(KeyCode.D))
        {
            inputES.InvokeStartRightEvent();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            inputES.InvokeStopRightEvent();
        }


        if (Input.GetKeyDown(KeyCode.Space)) {
            inputES.InvokeJumpEvent();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            inputES.InvokePrepareToFireEvent();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            inputES.InvokeFireEvent();
        }



        float shift = Input.GetAxis("Mouse ScrollWheel");
        inputES.InvokeChangeCameraDistance(shift);

        shift = Input.GetAxis("Mouse X");
        inputES.InvokeTurnHorizontalEvent(shift * Time.deltaTime);

        shift = Input.GetAxis("Mouse Y");
        inputES.InvokeTurnVerticalEvent(shift * Time.deltaTime);




        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            inputES.InvokeHitEvent();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            inputES.InvokeNextSpell();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            inputES.InvokePreviousSpell();
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) {
            inputES.InvokeStartMoveCamera();
        }
        if (Input.GetKeyUp(KeyCode.RightControl)) {
            inputES.InvokeStopMoveCamera();
        }

        if (Input.GetKeyDown(KeyCode.Mouse2) || Input.GetKeyDown(KeyCode.Keypad5)) {
            inputES.InvokeLoadCameraDefaults();
        }


        if (Input.GetKeyDown(KeyCode.P)) {
            inputES.InvokePauseModeEvent();
        }

    } // UPDATE() //

} // End Of Class //

