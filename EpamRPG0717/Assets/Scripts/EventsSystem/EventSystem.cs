using System;
using UnityEngine;

public static class EventSystem {

    public static event Action startForwardEvent;
    public static event Action startRightEvent;
    public static event Action startLeftEvent;
    public static event Action startBackEvent;

    public static event Action stopForwardEvent;
    public static event Action stopRightEvent;
    public static event Action stopLeftEvent;
    public static event Action stopBackEvent;

    public static event Action<float> TurnHorizontalEvent;
    public static event Action<float> TurnVerticalEvent;

    public static event Action jumpEvent;
    public static event Action<Vector3> fireEvent;
    public static event Action hitEvent;

}