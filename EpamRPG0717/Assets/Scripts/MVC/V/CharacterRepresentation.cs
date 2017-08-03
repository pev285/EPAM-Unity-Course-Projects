using System.Text;
using UnityEngine;

public class CharacterRepresentation : MonoBehaviour {

    private int jumpHash = Animator.StringToHash("Jump");
    private int runHash = Animator.StringToHash("Run");
    private int attackHash = Animator.StringToHash("Attack");
    private int walkHash = Animator.StringToHash("Walk");


    private Animator animator;



//    [SerializeField]
    private GameObject character;
    private CharacterModel model;

    private Rigidbody rgBody;

//    private KeyBinder gameModeKeyBinder = GameManager.GameModeKeyBinder;
//

    private KeyBinder gameModeKeyBinder;// = GameManager.Instance.GameModeKeyBinder;


/////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////


	// Use this for initialization
	void Start () {
        character = gameObject;
		model = character.GetComponent<CharacterModel>();

        rgBody = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();



        gameModeKeyBinder = GameManager.Instance.GameModeKeyBinder;

      //  subscribeAnimationEvent();

        subscribeMovementEvents();
	}

    private void subscribeMovementEvents() {

    }

    /*
    private void subscribeAnimationEvent() {

        gameModeKeyBinder.StartListening(KeyboardEventType.StartRunForward, delegate  {
            animator.SetBool(runHash, true);
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.StopRunForward, delegate  {
            animator.SetBool(runHash, false);
        });

        gameModeKeyBinder.StartListening(KeyboardEventType.PowerAttack, delegate  {
            animator.SetTrigger(attackHash);
        });

        gameModeKeyBinder.StartListening(KeyboardEventType.Jump, delegate  {
            animator.SetTrigger(jumpHash);
        });

        gameModeKeyBinder.StartListening(KeyboardEventType.Walking, delegate  {
            animator.SetBool(walkHash, true);
        });
        gameModeKeyBinder.StartListening(KeyboardEventType.NotWalking, delegate  {
            animator.SetBool(walkHash, false);
        });


    }
    */
	
	// Update is called once per frame
	void FixedUpdate () {



        float forwrardVelocity = model.GetForwardVelocity() * Time.deltaTime;
        float sidewardVelocity = model.GetSidewardVelocity() * Time.deltaTime;
        float horizontalRotation = model.GetHorizontalRotation() * Time.deltaTime;
//        float verticalRotation = model.GetVerticalRotation();


        // Horizontal Rotation //

        if (horizontalRotation != 0) {
            rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(horizontalRotation, Vector3.up ));
        }


        //

        if (forwrardVelocity != 0) {
            Vector3 velocityForward = transform.forward * forwrardVelocity;
            rgBody.velocity = new Vector3(velocityForward.x, rgBody.velocity.y, velocityForward.z);
        } else {

        }

        if (sidewardVelocity != 0) {
            Vector3 velRight = transform.right * sidewardVelocity;
            rgBody.velocity = new Vector3(velRight.x, rgBody.velocity.y, velRight.z);

        }


        // IsJumping //
        float jumpUpForce = model.GetJumpForce();


        if (jumpUpForce > 0) {

            rgBody.AddForce((transform.up) * jumpUpForce, ForceMode.Impulse);
//            rgBody.velocity = new Vector3(rgBody.velocity.x, jumpUpVelocity, rgBody.velocity.z);
        }



	}

}
