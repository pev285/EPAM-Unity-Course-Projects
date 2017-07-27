using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : AbstractCharacterModel {


//    private GameObject attackingPoint;

    // GoundCheck //
    private bool isGrounded = true;
    private float lastTimeY = 0;
    private const float GROUND_EPS = 0.005f; //0.000001f;


    [SerializeField]
    private bool windAttacking = false;
    [SerializeField]
    private bool magnitoAttacking = false;
    [SerializeField]
    private bool jumping = false;

    // Position of the character in Game space.
    private Vector3 position;


    public bool IsGrounded {
        get {return isGrounded;}
    }

    public bool IsJumping {
        get {return jumping; }
    }

    public void Forward() {

    }

    public void Backward() {

    }

    public void StepRight() {

    }

    public void StepLeft() {

    }

    public void Jump() {

    }

    public void Stop() {

    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////

	// Use this for initialization
	void Start () {
		position = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {





        RecalculateGrounded();

	} // UPDATE() //



    private void RecalculateGrounded() {

        // If character vertical position didn't change much, mark him grounded //
        if (Mathf.Abs(lastTimeY - position.y) < GROUND_EPS) {
            isGrounded = true;
        } else {
            isGrounded = false;
            lastTimeY = position.y;
        }
    } // Recalc Ground //


} // End Of Class //

