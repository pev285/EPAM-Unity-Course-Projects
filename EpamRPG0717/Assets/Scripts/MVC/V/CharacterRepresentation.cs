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






/////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////


	// Use this for initialization
	void Start () {
        character = gameObject;
		model = character.GetComponent<CharacterModel>();

        rgBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();


	}
	
	// Update is called once per frame
	void FixedUpdate () {



        float forwrardVelocity = model.GetForwardVelocity();
        float sidewardVelocity = model.GetSidewardVelocity();
        float horizontalRotation = model.GetHorizontalRotation();
//        float verticalRotation = model.GetVerticalRotation();


        // Horizontal Rotation //

        if (horizontalRotation != 0) {
//            print("rotation:" + horizontalRotation);
            rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(horizontalRotation, Vector3.up ));
        }


        //

        if (forwrardVelocity != 0) {
            Vector3 velocityForward = transform.forward * forwrardVelocity;
            rgBody.velocity = new Vector3(velocityForward.x, rgBody.velocity.y, velocityForward.z);
        } else {

        }

        if (forwrardVelocity > 0) {
            animator.SetBool(runHash, true);
        } else {
            animator.SetBool(runHash, false);

            if (forwrardVelocity < 0) {
                animator.SetBool(walkHash, true);
            }
        }

        if (sidewardVelocity != 0) {
            animator.SetBool(walkHash, true);

            Vector3 velRight = transform.right * sidewardVelocity;
            rgBody.velocity = new Vector3(velRight.x, rgBody.velocity.y, velRight.z);

        } else {

        }

        if (forwrardVelocity >= 0 && sidewardVelocity == 0) {
            animator.SetBool(walkHash, false);
        }


        // IsJumping //
        float jumpUpForce = model.GetJumpForce();

        if (jumpUpForce > 0) {
            animator.SetTrigger(jumpHash);

            rgBody.AddForce((transform.up) * jumpUpForce, ForceMode.Impulse);
//            rgBody.velocity = new Vector3(rgBody.velocity.x, jumpUpVelocity, rgBody.velocity.z);
        }

        // SpecialAttacking //

        if (model.IsSpecialAttacking) {
            animator.SetTrigger(attackHash);
        }



	}
}
