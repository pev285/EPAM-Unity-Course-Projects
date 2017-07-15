using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkingAnimator : MonoBehaviour, IAnimator   {

    void IAnimator.Die()
    {
        Timer t = new Timer(gameObject, delegate ()
        {
            Vector3 scale = gameObject.transform.localScale;
            float factor = 0.80f;
            transform.localScale = Vector3.Scale(scale, new Vector3(factor, factor, factor));
        }, 0.01f, 10);

        //transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
