using System;
using UnityEngine;

public static class EventSystem {

    public static event Action runForwardEvent;
    public static event Action walkRightEvent;
    public static event Action walkLeftEvent;
    public static event Action walkBackEvent;

    public static event Action<float> TurnHorizontalEvent;
    public static event Action<float> TurnVerticalEvent;

    public static event Action jumpEvent;
    public static event Action<Vector3> fireEvent;
    public static event Action hitEvent;

}