using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzzzEnemyModel : AbstractCharacterControllingModel {


    //    private GameObject attackingPoint;

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
    private float forwardVelocity = 0;
    [SerializeField]
    private float sidewardVelocity = 0;
    [SerializeField]
    private float horizontalRotationAmount = 0;
    [SerializeField]
    private float verticalRotationAmount = 0;


    //////////////////////////////////////////////

    [SerializeField]
    private const float mouseWeelSpeed = 6.0f;
    [SerializeField]
    private float vertRotationSpeed = 2f; //0.5f;
    [SerializeField]
    private float horizRotationSpeed = 2f; //0.5f;



    [SerializeField]
    private float runSpeed = 30f;//120f;
    [SerializeField]
    private float walkSpeed = 15f; //80f;

    [SerializeField]
    private float jumpUpForce = 200f;
    private float jumpUpVelocity = 5f; // если использовать прыжок по velocity, а не по силе

    [SerializeField]
    private bool turnableAround = true;

    //////////////////////////////////////////////////////

    private Dispatcher gameModeKeyBinder;

    private EquippedSpells spells;



    private void SubscribeOnKeyboardEvents()
    {
        gameModeKeyBinder = GameManager.Instance.EnemyKeyBinder;

        gameModeKeyBinder.StartListening(DispatcherEventType.StartRunForward, delegate {
            print("fadkfja;skjdf;aljd;flkajsd;lkfj");
            forwardVelocity = runSpeed;
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.StopRunForward, delegate {
            forwardVelocity = 0;
        });

        gameModeKeyBinder.StartListening(DispatcherEventType.StartWalkBackward, delegate {
            forwardVelocity = -walkSpeed;
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.StopWalkBackward, delegate {
            forwardVelocity = 0;
        });

        gameModeKeyBinder.StartListening(DispatcherEventType.Jump, delegate {
            if (IsGrounded)
            {
                jumping = true;
            }
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.TurnRight, delegate {
            if (turnableAround)
            {
                horizontalRotationAmount = horizRotationSpeed * Input.GetAxis("Mouse X");
            }
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.TurnLeft, delegate {
            if (turnableAround)
            {
                horizontalRotationAmount = horizRotationSpeed * Input.GetAxis("Mouse X");
            }
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.StopHorizontalMouseMotion, delegate {
            horizontalRotationAmount = 0;
        });

        gameModeKeyBinder.StartListening(DispatcherEventType.StopCharRotation, delegate {
            turnableAround = false;
            horizontalRotationAmount = 0;
        });
        gameModeKeyBinder.StartListening(DispatcherEventType.ResumeCharRotation, delegate {
            turnableAround = true;
        });

    }

    ///////////////////////////////////////////////////////////




    public override void MoveForward()
    {
        forwardVelocity = runSpeed * Time.deltaTime;
    }

    public override void MoveBackward()
    {
        forwardVelocity = -walkSpeed * Time.deltaTime;
    }

    public override void MoveRight()
    {
        sidewardVelocity = walkSpeed * Time.deltaTime;
    }

    public override void MoveLeft()
    {
        sidewardVelocity = -walkSpeed * Time.deltaTime;
    }

    public override void Jump()
    {
        if (IsGrounded)
        {
            jumping = true;
        }
    }

    public override void SpecialAttack()
    {
        if (IsGrounded)
        {
            specialAttack = true;
        }
    }

    public override void TurnHorizontal(float shift)
    {
        horizontalRotationAmount = horizRotationSpeed * shift * Time.deltaTime;
    }

    public override void TurnVertical(float shift)
    {
        verticalRotationAmount = vertRotationSpeed * shift * Time.deltaTime;
    }


    //    public void StopForward() {
    //        forwardVelocity = 0;
    //    }
    //
    //    public void StopSideward() {
    //        sidewardVelocity = 0;
    //    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////



    public override bool IsGrounded
    {
        get { return isGrounded; }
    }

    //    public bool IsJumping {
    //        get {
    //            if (jumping) {
    //                jumping = false;
    //                return true;
    //            }
    //            return false;
    //        }
    //    }

    public override float GetJumpForce()
    {
        if (jumping)
        {
            jumping = false;
            return jumpUpForce;
        }
        return 0;
    }

    public override bool IsSpecialAttacking
    {
        get
        {
            if (specialAttack)
            {
                specialAttack = false;
                return true;
            }
            return false;
        }
    }


    public override float GetForwardVelocity()
    {
        float tmp = forwardVelocity; // * Time.deltaTime;
                                     //        forwardVelocity = 0;
        return tmp;
    }

    public override float GetSidewardVelocity()
    {
        float tmp = sidewardVelocity; // * Time.deltaTime;
                                      //        sidewardVelocity = 0;
        return tmp;
    }

    public override float GetHorizontalRotation()
    {
        float tmp = horizontalRotationAmount;// * Time.deltaTime;
                                             //        horizontalRotationAmount = 0;
        return tmp;
    }

    public override float GetVerticalRotation()
    {

        float tmp = verticalRotationAmount; // * Time.deltaTime;
                                            //        verticalRotationAmount = 0;
        return tmp;
    }


    /////////////////////////////////////////////////////////////////////////////////////////////////////
    //**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**//**/////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////

    // Use this for initialization
    void Start()
    {

        //position = gameObject.transform.position;
        lastTimeY = gameObject.transform.position.y;

        spells = GetComponent<EquippedSpells>();

        SubscribeOnKeyboardEvents();
    }

    // Update is called once per frame
    void Update()
    {

        RecalculateGrounded();

    } // UPDATE() //



    private void RecalculateGrounded()
    {

        // If character vertical position didn't change much, mark him grounded //
        if (Mathf.Abs(lastTimeY - transform.position.y) < GROUND_EPS)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        lastTimeY = transform.position.y;
    } // Recalc Ground //


} // End Of Class //

