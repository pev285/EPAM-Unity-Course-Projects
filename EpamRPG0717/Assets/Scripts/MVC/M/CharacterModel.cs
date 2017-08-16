using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : AbstractCharacterControllingModel {



    // GoundCheck //
    [SerializeField]
    private bool isGrounded = true;
    private float lastTimeY = 0;
    private const float GROUND_EPS = 0.005f; //0.000001f;


    [SerializeField]
    private bool specialAttack = false;
    [SerializeField]
    private bool jumping = false;
    [SerializeField]
    private bool isTargeting = false;

    [SerializeField]
    private float forwardVelocity = 0;
    [SerializeField]
    private float sidewardVelocity = 0;
    [SerializeField]
    private float horizontalRotationAmount = 0;
//    [SerializeField]
//    private float verticalRotationAmount = 0;


    //////////////////////////////////////////////

    [SerializeField]
    private const float mouseWeelSpeed = 6.0f;
    [SerializeField]
//    private float vertRotationSpeed = 2f; //0.5f;
//    [SerializeField]
    private float horizRotationSpeed = 30f; //0.5f;



    [SerializeField]
    private float runSpeed = 140f;//120f;
    [SerializeField]
    private float walkSpeed = 100f; //80f;

    [SerializeField]
    private float jumpUpForce = 200f;
    private float jumpUpVelocity = 5f; // если использовать прыжок по velocity, а не по силе

    [SerializeField]
    private bool turnableAround = true;


    [SerializeField]
    private Vector3 startingPosition;


    //////////////////////////////////////////////////////

    private GameObject targetingObject;
    public void SetTargetingObject(GameObject obj)
    {
        targetingObject = obj;
    }



    private EquippedSpells spells;

    private ControllerEventSystem ces;

    public void SetEventsSystem(ControllerEventSystem ces)
    {
        this.ces = ces;

        SubscribeOnKeyboardEvents();
    }

    public void SetSpells(EquippedSpells spells) {
        this.spells = spells;
    }

    private void SubscribeOnKeyboardEvents() {

        ces.startForwardEvent += MoveForward;
        ces.stopForwardEvent += StopMoveForward;

        ces.startRightEvent += MoveRight;
        ces.stopRightEvent += StopMoveRight;

        ces.startLeftEvent += MoveLeft;
        ces.stopLeftEvent += StopMoveLeft;

        ces.startBackEvent += MoveBackward;
        ces.stopBackEvent += StopMoveBackward;


        ces.jumpEvent += Jump;

        ces.turnHorizontalEvent += TurnHorizontal;

        ces.fireEvent += SpecialAttack;


        ces.startMoveCameraEvent += HorizontalRotationOff;
        ces.stopMoveCameraEvent += HorizontalRotationOn;

//        hitEvent;
//
        ces.nextSpellEvent += NextSpell;
        ces.previousSpellEvent += PrevSpell;

        ces.stopAllEvent += StopAllMovements;

    }

    public void NextSpell() {
        spells.ShiftForward();
    }
    public void PrevSpell() {
        spells.ShiftBackward();
    }
    public void CastSpell() {
        spells.GetCurrentSpell().Cast(gameObject, targetingObject.transform.rotation); //GameManager.Instance.GetPlayerCameraRotation()
    }




public void HorizontalRotationOn() {
        turnableAround = true;
    }

    public void HorizontalRotationOff() {
        turnableAround = false;
    }

    ///////////////////////////////////////////////////////////


    public override void StopAllMovements()
    {
        forwardVelocity = 0;
        sidewardVelocity = 0;
        horizontalRotationAmount = 0;
        jumping = false;
    }


    public override void MoveForward() {
        forwardVelocity += runSpeed;
        if (forwardVelocity > runSpeed) {
            forwardVelocity = runSpeed;
        }
    }
    public override void StopMoveForward() {
        forwardVelocity -= runSpeed;
//        if (forwardVelocity > 0 ) {
//            forwardVelocity = 0;
//        }
    }

    public override void MoveBackward() {
        forwardVelocity -= walkSpeed;
        if (forwardVelocity < -walkSpeed) {
            forwardVelocity = -walkSpeed;
        }
    }
    public override void StopMoveBackward() {
        forwardVelocity += walkSpeed;
//        if (forwardVelocity < 0) {
//            forwardVelocity = 0;
//        }
    }

    public override void MoveRight() {
        sidewardVelocity += walkSpeed;
        if (sidewardVelocity > walkSpeed) {
            sidewardVelocity = walkSpeed;
        }
    }
    public override void StopMoveRight() {
        sidewardVelocity -= walkSpeed;
//        if (sidewardVelocity > 0) {
//            sidewardVelocity = 0;
//        }
    }

    public override void MoveLeft() {
        sidewardVelocity -= walkSpeed;
        if (sidewardVelocity < -walkSpeed) {
            sidewardVelocity = -walkSpeed;
        }
    }
    public override void StopMoveLeft() {
        sidewardVelocity += walkSpeed;
//        if (sidewardVelocity < 0) {
//            sidewardVelocity = 0;
//        }
    }


    public override void Jump() {
        if (IsGrounded) {
            jumping = true;
        }
    }

    public override void SpecialAttack() {
        if (IsGrounded) {
            specialAttack = true;
        }

        CastSpell();
    }

    public override void TurnHorizontal(float shift) {
        if (turnableAround) {
            horizontalRotationAmount = horizRotationSpeed * shift;
        }
    }

    public override void TurnVertical(float shift) {
//        verticalRotationAmount = vertRotationSpeed * shift;
    }



    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////


    public override  bool IsTargeting {
        get { return isTargeting; }
    }

    public override bool IsGrounded
    {
        get { return isGrounded; }
    }


    public override bool IsJumping
    {
        get { return jumping; }
    }




    public override float GetJumpForce() {
        if (jumping) {
            jumping = false;
            return jumpUpForce;
        }
        return 0;
    }

    public override bool IsSpecialAttacking {
        get {
            if (specialAttack) {
                specialAttack = false;
                return true;
            }
            return false;
        }
    }


    public override float GetForwardVelocity() {
        float tmp = forwardVelocity; 
//        forwardVelocity = 0;
        return tmp;
    }

    public override float GetSidewardVelocity() {
        float tmp = sidewardVelocity; 
//        sidewardVelocity = 0;
        return tmp;
    }

    public override float GetHorizontalRotation() {
        float tmp = horizontalRotationAmount;
//        horizontalRotationAmount = 0;
        return tmp;
    }

    public override float GetVerticalRotation() {

        float tmp = 0;//verticalRotationAmount;
//        verticalRotationAmount = 0;
        return tmp;
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////

	void Start () {

        startingPosition = transform.position;


        lastTimeY = gameObject.transform.position.y;

//        spells = GetComponent<EquippedSpells>();
	}
	
	void Update () {

        RecalculateGrounded();

	} // UPDATE() //



    private void RecalculateGrounded() {

        // If character vertical position didn't change much, mark him grounded //
        if (Mathf.Abs(lastTimeY - transform.position.y) < GROUND_EPS) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
        lastTimeY = transform.position.y;
    } // Recalc Ground //


} // End Of Class //

