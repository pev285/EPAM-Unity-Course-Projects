using System;
using UnityEngine;

public class PlayerController01 : MonoBehaviour {

    private GameObject playerCamera;
    private GameObject headTop;
    private GameObject powerAttackPoint;

    private Rigidbody rgBody;


    ////////////////////////////////////////////////////////

    [SerializeField]
    private float player2cameraDistance;

    [SerializeField ]
    private Vector3 player2cameraDirection;

    [SerializeField]
    private Vector3 playerOrientation;

    [SerializeField]
    private Quaternion cameraRotation;
    [SerializeField]
    private Vector3 playerDirection;


    private const float minCameraDistance = 1f;


    private const float mouseWeelSpeed = 3.0f;
    private const float defaultCameraDistance = 1.5f;
    private Vector3 defaultPlayer2cameraDirection = new Vector3(-0.7f, 0.7f, -0.2f);



    private Quaternion defaultCameraRotation;

    ////////////////////////////////////////////////////////

    [SerializeField]
    private float runSpeed = 2f;
    [SerializeField]
    private float walkSpeed = 1f;
    [SerializeField]
    private float rotationSpeed = 0.5f;
    [SerializeField]
    private float moveAmount;
    [SerializeField]
    private float rotationAmount;
    [SerializeField]
    private float stepAside;


    [SerializeField]
    private float attackRadius = 3f;
    [SerializeField]
    private float powerAttackForce = 300f;



    [SerializeField]
    private bool attacking = false;
    [SerializeField]
    private bool jumping = false;
    [SerializeField]
    private bool grounded = true;



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

        headTop = GameObject.Find("Player/HeadTop");

        playerCamera = GameObject.Find("Player/PlayerCamera");

        powerAttackPoint = GameObject.Find("Player/PowerAttackPoint");

        animator = GetComponent<Animator>();

        playerDirection = transform.forward;

        player2cameraDirection = playerCamera.transform.position - headTop.transform.position;

        player2cameraDistance = player2cameraDirection.magnitude;

        player2cameraDirection = player2cameraDirection.normalized;

        cameraRotation = playerCamera.transform.rotation;
    }



	// Update is called once per frame
	void Update () {

        // Read INPUT //

        player2cameraDistance -= mouseWeelSpeed*(Input.GetAxis("Mouse ScrollWheel"));
        if (player2cameraDistance < minCameraDistance) {
            player2cameraDistance = minCameraDistance;
        }

        Messaging.SetTechInfoText("mouseX:" + Input.GetAxis("Mouse X") + ",  mouseY:" + Input.GetAxis("Mouse Y"));


        ChooseWeapon();
        ReadMovementControls();
        Fire();



	}


    void FixedUpdate() {

        CheckGround();
        MoveCharacter();

        MoveCamera();
    }



    private void CheckGround() {
        grounded = Mathf.Abs(transform.position.y) < 0.000001f;

        if (!grounded) {
            jumping = false;
        }
    }


    private void Fire() {

    } // Fire() //

    private void ReadMovementControls() {


        rotationAmount = Input.GetAxis("Mouse X");

        if (Input.GetKey(KeyCode.A)) {
            stepAside = -1;
        } else if (Input.GetKey(KeyCode.D)) {
            stepAside = 1;
        } else {
            stepAside = 0;
        }

        if (Input.GetKey(KeyCode.W)) {
            moveAmount = 1;
        } else if (Input.GetKey(KeyCode.S)) {
            moveAmount = -1;
        } else {
            moveAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            jumping = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            attacking = true;
        }


        // Move Camera //

        if (Input.GetKey(KeyCode.Keypad5)) {
            player2cameraDirection = defaultPlayer2cameraDirection;
            player2cameraDistance = defaultCameraDistance;
        }

        if (Input.GetKey(KeyCode.Keypad4)) {

            Quaternion q = Quaternion.AngleAxis(10, Vector3.up);
//            player2cameraDirection

            cameraRotation = q * cameraRotation;
            player2cameraDirection = q * player2cameraDirection;
        } else if (Input.GetKey(KeyCode.Keypad6)) {

            Quaternion q = Quaternion.AngleAxis(-10, Vector3.up);
//            player2cameraDirection

            cameraRotation = q * cameraRotation;
            player2cameraDirection = q * player2cameraDirection;
        }


        // /// /// /// //

    } // Read Movement Contrlols() //



    private void MoveCharacter() {

        if (jumping && grounded) {
            animator.SetTrigger(jumpHash);
            jumping = false;

            rgBody.AddForce((transform.forward + transform.up) , ForceMode.Impulse);

        }

        if (attacking && grounded) {
            animator.SetTrigger(attackHash);
            attacking = false;

            new Timer(this.gameObject, delegate {
                BlowThemAway();
            }, 0.5f);
//            BlowThemAway();
        }

        if (stepAside == 0) {
            animator.SetBool(walkHash, false);
        } else {
            animator.SetBool(walkHash, true);

            if (stepAside > 0) {
                rgBody.velocity = transform.right * walkSpeed * Time.deltaTime;
            } else {
                rgBody.velocity = -transform.right * walkSpeed * Time.deltaTime;
            }

        }

        if (moveAmount == 0) {
            animator.SetBool(runHash, false);
        } else {
            animator.SetBool(runHash, true);

            if (moveAmount > 0) { // Move Forward //

            } else if (moveAmount < 0) { // Move Backward //

            }
        }



        if (moveAmount > 0) {
//            rgBody.AddForce(transform.forward * runSpeed * Time.deltaTime, ForceMode.Impulse);
            rgBody.velocity = transform.forward * runSpeed * Time.deltaTime;
//            rgBody.MovePosition(transform.position + Time.deltaTime * runSpeed * transform.forward );
        }
//        if (Input.GetKey(KeyCode.DownArrow)) {
//            Vector3 backward = transform.rotation * Vector3.back;
//            rgBody.MovePosition(transform.position + Time.deltaTime * speed * backward);
//        }



        if (rotationAmount != 0) {
            rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(rotationSpeed * rotationAmount, Vector3.up ));
        }

    }


    private void BlowThemAway() {

        Vector3 explosionPos = powerAttackPoint.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, attackRadius);

        print("num of colliders=" + colliders.Length);

        foreach (Collider hit in colliders) {


            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null) {
                print("rb found");

                //rb.velocity = new Vector3(1f, 1f, 1f);

                rb.AddExplosionForce(powerAttackForce, explosionPos, attackRadius, 3.0F);
            }

        }

    }

    private void MoveCamera() {

//        playerCamera.transform.position = (headTop.transform.position + player2cameraDirection * player2cameraDistance);
//        playerCamera.transform.rotation = cameraRotation;
    }


    private void ChooseWeapon() {

        if (Input.GetKey(KeyCode.Alpha1)) {
// Choose weapon 1
        } else if (Input.GetKey(KeyCode.Alpha2)) {
// Coose weapon 2
        }


    } // ChooseWeapon() //





}// End Of Class //


