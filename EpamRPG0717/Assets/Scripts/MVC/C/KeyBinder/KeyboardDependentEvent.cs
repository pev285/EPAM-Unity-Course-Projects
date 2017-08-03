using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardDependentEvent {

//    public delegate bool EventCondition(KeyCode code);
    public delegate bool EventCondition();



//    public KeyCode KeyCode { get; set; }
    public KeyboardEventType Type { get; set; }
    public EventCondition Condition { get; set; }

//    public List<Action>  Actions ;
    public UnityEvent KeyEvent;

//    public KeyboardDependentEvent(KeyCode code, EventCondition condition, KeyboardEventType type) {
    public KeyboardDependentEvent(EventCondition condition, KeyboardEventType type) {
        KeyEvent = new UnityEvent();
//        this.KeyCode = code;
        this.Condition = condition;
        this.Type = type;
    }


}