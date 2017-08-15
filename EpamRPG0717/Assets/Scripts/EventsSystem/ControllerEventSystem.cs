using System;
using UnityEngine;

public class ControllerEventSystem
{

    public event Action startForwardEvent;
    public event Action startRightEvent;
    public event Action startLeftEvent;
    public event Action startBackEvent;

    public event Action stopForwardEvent;
    public event Action stopRightEvent;
    public event Action stopLeftEvent;
    public event Action stopBackEvent;
    public event Action stopAllEvent;

    public event Action<float> turnHorizontalEvent;
    public event Action<float> turnVerticalEvent;
    public event Action<float> changeCameraDistanceEvent;

    public event Action jumpEvent;

    public event Action prepareToFireEvent;
    public event Action fireEvent;

    public event Action hitEvent;

    public event Action nextSpellEvent;
    public event Action previousSpellEvent;

    public event Action startMoveCameraEvent;
    public event Action stopMoveCameraEvent;
    public event Action loadCameraDefaultsEvent;

    public event Action pauseModeEvent;

    /////////////////////////////////////////////////////////////////

    public void InvokeStopAllEvent()
    {
        if (stopAllEvent != null)
        {
            stopAllEvent();
        }
    }

    public void InvokePauseModeEvent() {
        if (pauseModeEvent != null) {
            pauseModeEvent();
        }
    }

    public void InvokeStartForwardEvent()
    {
        if (startForwardEvent != null) {
            startForwardEvent();
        }
    }
    public void InvokeStopForwardEvent()
    {
        if (stopForwardEvent != null) {
            stopForwardEvent();
        }
    }

    public void InvokeStartRightEvent() {
        if (startRightEvent != null) {
            startRightEvent();
        }
    }
    public void InvokeStopRightEvent() {
        if (stopRightEvent != null) {
            stopRightEvent();
        }
    }

    public void InvokeStartLeftEvent() {
        if (startLeftEvent != null) {
            startLeftEvent();
        }
    }
    public void InvokeStopLeftEvent() {
        if (stopLeftEvent != null) {
            stopLeftEvent();
        }
    }

    public void InvokeStartBackEvent() {
        if (startBackEvent != null) {
            startBackEvent();
        }
    }
    public void InvokeStopBackEvent() {
        if (stopBackEvent != null) {
            stopBackEvent();
        }
    }



    public void InvokeTurnHorizontalEvent(float shift)
    {
        if (turnHorizontalEvent != null) {
            turnHorizontalEvent(shift);
        }
    }

    public void InvokeTurnVerticalEvent(float shift) {
        if (turnVerticalEvent != null) {
            turnVerticalEvent(shift);
        }
    }

    public void InvokeChangeCameraDistance(float shift) {
        if (changeCameraDistanceEvent != null) {
            changeCameraDistanceEvent(shift);
        }
    }


    public void InvokeJumpEvent() {
        if (jumpEvent != null) {
            jumpEvent();
        }
    }

    public void InvokePrepareToFireEvent() {
        if (prepareToFireEvent != null) {
            prepareToFireEvent();
        }
    }

    public void InvokeFireEvent() {
        if (fireEvent != null) {
            fireEvent();
        }
    }

    public void InvokeHitEvent() {
        if (hitEvent != null) {
            hitEvent();
        }
    }

    public void InvokeNextSpell() {
        if (nextSpellEvent != null) {
            nextSpellEvent();
        }
    }
    public void InvokePreviousSpell() {
        if (previousSpellEvent != null) {
            previousSpellEvent();
        }
    }


    public void InvokeStartMoveCamera() {
        if (startMoveCameraEvent != null) {
            startMoveCameraEvent();
        }
    }
    public void InvokeStopMoveCamera() {
        if (stopMoveCameraEvent != null) {
            stopMoveCameraEvent();
        }
    }
    public void InvokeLoadCameraDefaults() {
        if (loadCameraDefaultsEvent != null) {
            loadCameraDefaultsEvent();
        }
    }


} // End Of Class //


