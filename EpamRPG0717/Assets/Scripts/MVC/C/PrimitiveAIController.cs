using UnityEngine;

public class PrimitiveAIController : MonoBehaviour {

    private ControllerEventSystem inputES;

    public void SetControllerEventSystem(ControllerEventSystem ces)
    {
        inputES = ces;
    }

// ******************************************************************************************* //


    private float lastTime = Time.time;

// Use this for initialization
    void Start () {

    }

// Update is called once per frame
    void Update () {

        float deltaTime = Time.time - lastTime;

//        inputES.InvokeStartForwardEvent();

        if (Time.time % 10 == 5)
        {
            inputES.InvokeStopRightEvent();
            inputES.InvokeStartForwardEvent();
        }
        else if (Time.time % 10 == 0)
        {
            inputES.InvokeStopForwardEvent();
            inputES.InvokeStartRightEvent();
        }



//        lastTime = Time.time;

    } // UPDATE() //

}