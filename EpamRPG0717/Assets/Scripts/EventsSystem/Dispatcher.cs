using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dispatcher : MonoBehaviour{

    private Dictionary<DispatcherEventType, DispatcherEvent> keyEvents;

    void Awake() {
        keyEvents = new Dictionary<DispatcherEventType, DispatcherEvent>();
    }


    void Start() {
    }

    public void StartListening(DispatcherEventType type, UnityAction action) {
        if (keyEvents.ContainsKey(type)) {
            keyEvents[type].KeyEvent.AddListener(action);
        } else {
            print("No such keyboard event: " + type.ToString());
        }
    }


    public void AddKeyEvent(DispatcherEvent keyEvent) {
        keyEvents.Add(keyEvent.Type, keyEvent);
    }





    void Update() {

        foreach (DispatcherEvent e in keyEvents.Values) {
//            if (e.Condition(e.KeyCode)) {
            if (e.Condition()) {
                e.KeyEvent.Invoke();
            }
        }
    }


}