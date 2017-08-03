using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBinder : MonoBehaviour{

    private Dictionary<KeyboardEventType,KeyboardDependentEvent> keyEvents;

    void Awake() {
        keyEvents = new Dictionary<KeyboardEventType, KeyboardDependentEvent>();
    }


    void Start() {
    }

    public void StartListening(KeyboardEventType type, UnityAction action) {
        if (keyEvents.ContainsKey(type)) {
            keyEvents[type].KeyEvent.AddListener(action);
        } else {
            print("No such keyboard event: " + type.ToString());
        }
    }


    public void AddKeyEvent(KeyboardDependentEvent keyEvent) {
        keyEvents.Add(keyEvent.Type, keyEvent);
    }





    void Update() {

        foreach (KeyboardDependentEvent e in keyEvents.Values) {
//            if (e.Condition(e.KeyCode)) {
            if (e.Condition()) {
                e.KeyEvent.Invoke();
            }
        }
    }


}