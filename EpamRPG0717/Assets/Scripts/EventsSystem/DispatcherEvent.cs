using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DispatcherEvent {

//    public delegate bool EventCondition(KeyCode code);
    public delegate bool EventCondition();



//    public KeyCode KeyCode { get; set; }
    public DispatcherEventType Type { get; set; }
    public EventCondition Condition { get; set; }

//    public List<Action>  Actions ;
    public UnityEvent KeyEvent;

//    public KeyboardDependentEvent(KeyCode code, EventCondition condition, KeyboardEventType type) {
    public DispatcherEvent(EventCondition condition, DispatcherEventType type) {
        KeyEvent = new UnityEvent();
//        this.KeyCode = code;
        this.Condition = condition;
        this.Type = type;
    }


}