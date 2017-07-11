using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FibonacciAutomata : MonoBehaviour {

    // Start numbers //
    private int N = 2;
    private int Fns1 = 1;
    private int Fn = 1;

    Text screenText;

    // proccess variables //
    private int phase = 0;
    private bool refreshNeeded = true;


    // First objects iniciation //
    public GameObject Fns1Obj;
    public GameObject FnObj;


    // Objects lists hoders //
    private ListHolder Fns1Holder;
    private ListHolder FnHolder;
    private ListHolder FtemporaryHolder;

    // Moving variables //
    private static float smoothTime = 0.35f; // 0.5f;
    private static float upHeight = 1.5f;
    private float unitSize = 1.05f;

    // Coords for relative positions //
    private Vector3 center = Vector3.zero;


    // Use this for initialization
    void Start () {
        screenText = GameObject.Find("text1").GetComponent<Text>();

        Fns1Obj.transform.position = new Vector3(center.x - unitSize, center.y, center.z);
        FnObj.transform.position = new Vector3(center.x + unitSize, center.y, center.z);

        LiList Fns1List = new LiList(Fns1Obj, null, null);
        LiList FnList = new LiList(FnObj, null, null);

        Fns1Holder = new ListHolder(Fns1List, unitSize);
        FnHolder = new ListHolder(FnList, unitSize);
        FtemporaryHolder = new ListHolder(null, unitSize);
	}
	


	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("Menu");
        }

        if (refreshNeeded)
        {


            screenText.text = "N = " + N + "\t F(" + (N - 1) + ")=" + Fns1 + "\t F(" + N + ")=" + Fn;

            refreshNeeded = false;
        }

        if (phase == 0)
        {
            if (Input.GetKeyDown("space"))
            {

                N++;
                int tmp = Fn;
                Fn += Fns1;
                Fns1 = tmp;

                refreshNeeded = true;

                phase = 1;

            }
        } else
        { // IF PHASE != 0 //

            //GameObject o = Instantiate(FnObj);
            //o.transform.position = new Vector3(1, 1, 1);

            //phase = 0;

            //print("phase=" + phase);
            Vector3 pos;

            switch (phase)
            {
                case 1:
                    FtemporaryHolder.SetList(FnHolder.CloneList());
                    //pos = FtemporaryHolder.GetTargetPosition();
                    FtemporaryHolder.MoveListTo(new Vector3(center.x + unitSize, center.y + upHeight, center.z), smoothTime);
                    phase = 2;
                    break;
                case 2:
                    if (! FtemporaryHolder.Moving())
                    {
                        phase = 3;
                        pos = Fns1Holder.GetTargetPosition();
                        Fns1Holder.MoveListTo(new Vector3(pos.x + unitSize, pos.y, pos.z), smoothTime);
                    }
                    break;
                case 3:
                    if (!Fns1Holder.Moving())
                    {
                        phase = 4;

                        Fns1Holder.AppendList(FnHolder.GetList());
                        FnHolder.SetList(Fns1Holder.GetList());
                        Fns1Holder.SetList(FtemporaryHolder.GetList());
                        FtemporaryHolder.SetList(null);

                        //FnHolder.Rearrange();

                        //pos = Fns1Holder.GetTargetPosition();
                        FnHolder.MoveListTo(new Vector3(center.x + unitSize, center.y, center.z), smoothTime);
                    }
                    break;
                case 4:
                    if (!FnHolder.Moving())
                    {
                        //FnHolder.Rearrange();
                        phase = 5;
                        Fns1Holder.MoveListTo(new Vector3(center.x - Fns1*unitSize, center.y, center.z), smoothTime);
                    }
                    break;
                case 5:
                    if (!Fns1Holder.Moving())
                    {
                        //Fns1Holder.Rearrange();
                        phase = 0;
                    }
                    break;
                case 6:
                    print("phase 6");
                    break;
                case 7:
                    print("phase 7");
                    break;
            }

        } // END IF PHASE != 0 //




    } // End of UPDATE() //


}// End Of Class //

