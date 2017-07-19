using System.Text;
using UnityEngine;

public class PlayerController02 : MonoBehaviour {

    private GameObject playerCamera;
    private GameObject headTop;
    private GameObject powerAttackPoint;

    private Rigidbody rgBody;


////////////////////////////////////////////////////////

    [SerializeField]
    private float player2cameraDistance;


	[SerializeField]
    private Vector3 cameraDirection;
    [SerializeField]
    private float cameraHorRotation;
    [SerializeField]
    private float cameraVertRotation;



    private const float minCameraDistance = 1f;
    private const float mouseWeelSpeed = 3.0f;
    private const float defaultCameraDistance = 1.5f;
    private const float defaultVertRotation = 35f;
    private const float defaultHorRotation = 0f;

    //private Vector3 defaultPlayer2cameraDirection = new Vector3(-0.7f, 0.7f, -0.2f);



    //private Quaternion defaultCameraRotation;

////////////////////////////////////////////////////////

    [SerializeField]
    private float runSpeed = 120f;
    [SerializeField]
    private float walkSpeed = 60f;
    [SerializeField]
    private float rotationSpeed = 0.5f;
    [SerializeField]
    private float moveAmount = 0;
    [SerializeField]
    private float rotationAmount = 0;
    [SerializeField]
    private float cameraAloneRotationAmount = 0;
    [SerializeField]
    private float stepAside = 0;


    [SerializeField]
    private float attackRadius = 3f;
    [SerializeField]
    private float powerAttackForce = 300f;
    [SerializeField]
    private float jumpUpForce = 200f;
    private float jumpUpVelocity = 5f; // если использовать прыжок по velocity, а не по силе



    [SerializeField]
    private bool attacking = false;
    [SerializeField]
    private bool jumping = false;
    [SerializeField]
    private bool grounded = true;

//////////////////////////////////////////////////////////////////////////

    private int jumpHash = Animator.StringToHash("Jump");
    private int runHash = Animator.StringToHash("Run");
    private int attackHash = Animator.StringToHash("Attack");
    private int walkHash = Animator.StringToHash("Walk");


    private Animator animator;


///////////////////////////////////////////////////////////////////////
// ***************************************************************** //
///////////////////////////////////////////////////////////////////////


// Use this for initialization
    void Start () {

        rgBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        headTop = GameObject.Find("Player/HeadTop");
        playerCamera = GameObject.Find("Player/PlayerCamera");
        powerAttackPoint = GameObject.Find("Player/PowerAttackPoint");

        SetCameraDefaults();

    } // Start() //



    private void SetCameraDefaults() {
        cameraDirection = transform.forward;
        player2cameraDistance = defaultCameraDistance;
        cameraVertRotation = defaultVertRotation;
        cameraHorRotation = defaultHorRotation;
    }




    private void MoveCamera() {

//        cameraDirection = transform.forward;

        Vector3 cameraRight;// = transform.right;
        cameraRight = Quaternion.AngleAxis(90f, Vector3.up) * cameraDirection;
        Quaternion cameraVerticalRotation = Quaternion.AngleAxis(cameraVertRotation, cameraRight);
		Vector3 newCameraPosition = cameraVerticalRotation * (-cameraDirection) * player2cameraDistance;

        Vector3 relativePosition = headTop.transform.position - playerCamera.transform.position;

        playerCamera.transform.position = headTop.transform.position + newCameraPosition;

        playerCamera.transform.rotation = Quaternion.LookRotation(relativePosition);
//        playerCamera.transform.rotation = transform.rotation * cameraVerticalRotation;
//        playerCamera.transform.position = (headTop.transform.position + player2cameraDirection * player2cameraDistance);
//        playerCamera.transform.rotation = cameraRotation;
    }



// Update is called once per frame
    void Update () {
        //ChooseWeapon();
        ReadMovementControls();

        SetScreenInformation();
    }

    void FixedUpdate() {
        CheckGround();
        MoveCharacter();

        MoveCamera();
    }




    private void SetScreenInformation() {
        StringBuilder sb = new StringBuilder();
        sb.Append("mouseX:").Append(Input.GetAxis("Mouse X")).Append( ",  mouseY:");
        sb.Append(Input.GetAxis("Mouse Y"));
        sb.Append("q:").Append(Quaternion.FromToRotation(transform.forward, -cameraDirection));
        sb.Append("\n");
        sb.Append("TransformForward:").Append(transform.forward).Append(", CamDirection:").Append(cameraDirection);

        Messaging.SetTechInfoText(sb.ToString());
    }



    // Is Player standing on the ground //
    private void CheckGround() {
        grounded = Mathf.Abs(transform.position.y) < 0.000001f;

        if (!grounded) {
            jumping = false;
        }
    }

    // Should we rotate camera but not the player ? //
    private bool IsPlayerFixed() {
        return Input.GetKey(KeyCode.RightControl);
    }



    private void ReadMovementControls() {


        float horizontalAngleChange = Input.GetAxis("Mouse X");
        float verticalViewAngleChange = Input.GetAxis("Mouse Y");


        // Player Character turning left/right //
        if (!IsPlayerFixed()){
            rotationAmount = horizontalAngleChange;
            cameraAloneRotationAmount = 0;
        } else { // Camera rotating when Player is standing still //
            rotationAmount = 0;
            cameraAloneRotationAmount = horizontalAngleChange;
        }



        // Step left || Step right //

        if (Input.GetKey(KeyCode.A)) {
            stepAside = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            stepAside = 1;
        } else {
            stepAside = 0;
        }

        // Step forward || Step backward //
        if (Input.GetKey(KeyCode.W)) {
            moveAmount = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveAmount = -1;
        } else {
            moveAmount = 0;
        }

        // Jump key //
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumping = true;
        }

        // Attack key //
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            attacking = true;
        }


// Move Camera // *****************************************************************

        // Vertical camera position //
        cameraVertRotation -= verticalViewAngleChange;


        // Adjast Player to Camera Distance //
        player2cameraDistance -= mouseWeelSpeed*(Input.GetAxis("Mouse ScrollWheel"));
        if (player2cameraDistance < minCameraDistance) {
            player2cameraDistance = minCameraDistance;
        }


        // Set camera default position //
        if (Input.GetKey(KeyCode.Keypad5) || Input.GetKey(KeyCode.Mouse2)) {
            SetCameraDefaults();
        }

        // Camera rotating when Player is standing still //
//        if (IsPlayerFixed()){
//
//            Quaternion quaternion = Quaternion.AngleAxis(rotationSpeed * horizontalAngleChange, Vector3.up);
//            cameraDirection = quaternion * cameraDirection;
//        }

    } // End of ReadMovementControls() //



    private void MoveCharacter() {

        // Jumping //
        if (jumping && grounded) {
            animator.SetTrigger(jumpHash);
            jumping = false;

//            rgBody.velocity = new Vector3(rgBody.velocity.x, jumpUpVelocity, rgBody.velocity.z);
            rgBody.AddForce((transform.up) * jumpUpForce, ForceMode.Impulse);

        }

        // Wind attack //
        if (attacking && grounded) {
            animator.SetTrigger(attackHash);
            attacking = false;

            new Timer(this.gameObject, delegate {
                BlowThemAway();
            }, 0.5f);

        }

        // Stepping away //
        if (stepAside == 0) {
            animator.SetBool(walkHash, false);
        } else {
            animator.SetBool(walkHash, true);

            Vector3 velRight = transform.right * walkSpeed * Time.deltaTime;

            if (stepAside > 0) {
                rgBody.velocity = new Vector3(velRight.x, rgBody.velocity.y, velRight.z);
            } else {
                rgBody.velocity = new Vector3(-velRight.x, rgBody.velocity.y, -velRight.z);
            }
        }

        // Moving forward or backward //
        if (moveAmount == 0) {
            animator.SetBool(runHash, false);
        } else {
//            animator.SetBool(runHash, true);
            animator.SetBool(runHash, true);

            if (moveAmount > 0) { // Move Forward //

                var velocityForward = transform.forward * runSpeed * Time.deltaTime;
                rgBody.velocity = new Vector3(velocityForward.x, rgBody.velocity.y, velocityForward.z);

            } else if (moveAmount < 0) { // Move Backward //

//                if (transform.forward != -cameraDirection) {
//                    Quaternion quaternion = Quaternion.FromToRotation(transform.forward, -cameraDirection);
//                    rgBody.MoveRotation(rgBody.rotation * quaternion);
//                }


                var velocityForward = -transform.forward * walkSpeed * Time.deltaTime;
                rgBody.velocity = new Vector3(velocityForward.x, rgBody.velocity.y, velocityForward.z);

            }
        }


        // Character rotation //
        if (rotationAmount != 0) {
            rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(rotationSpeed * rotationAmount, Vector3.up ));

            // Adjast Player Camera //
            Quaternion quaternion = Quaternion.AngleAxis(rotationSpeed * rotationAmount, Vector3.up);
            cameraDirection = quaternion * cameraDirection;
        }

        if (cameraAloneRotationAmount != 0) {
            Quaternion quaternion = Quaternion.AngleAxis(rotationSpeed * cameraAloneRotationAmount, Vector3.up);
            cameraDirection = quaternion * cameraDirection;
        }


    }



    // Superpower //
    private void BlowThemAway() {
        Vector3 explosionPos = powerAttackPoint.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, attackRadius);

        foreach (Collider col in colliders) {
            Rigidbody rb = col.GetComponent<Rigidbody>();

            if (rb != null) {
                rb.AddExplosionForce(powerAttackForce, explosionPos, attackRadius, 3.0F);
            }
        } // foreach collider //
    } // end of  BlowThemAway() //






    // Not Implemented //
    private void ChooseWeapon() {
        if (Input.GetKey(KeyCode.Alpha1)) {
// Choose weapon 1
        } else if (Input.GetKey(KeyCode.Alpha2)) {
// Coose weapon 2
        }
    } // ChooseWeapon() //



} // End Of Class PlayerController02 //

