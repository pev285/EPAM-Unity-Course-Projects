using System.Text;
using UnityEngine;

public class CharacterMover : MonoBehaviour {



//    [SerializeField]
    private GameObject character;
    private CharacterModel model;

    private Rigidbody rgBody;

//    private KeyBinder gameModeKeyBinder = GameManager.GameModeKeyBinder;
//



/////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////


	// Use this for initialization
	void Start () {
        character = gameObject;
		model = character.GetComponent<CharacterModel>();

        rgBody = GetComponent<Rigidbody>();



	}


	// Update is called once per frame
	void FixedUpdate () {



        float forwrardVelocity = model.GetForwardVelocity() * Time.deltaTime;
        float sidewardVelocity = model.GetSidewardVelocity() * Time.deltaTime;
        float horizontalRotation = model.GetHorizontalRotation();// * Time.deltaTime;
//        float verticalRotation = model.GetVerticalRotation();
        float jumpUpForce = model.GetJumpForce();
        bool attacking = model.IsSpecialAttacking;


        // Horizontal Rotation //

        if (horizontalRotation != 0) {
            rgBody.MoveRotation(rgBody.rotation * Quaternion.AngleAxis(horizontalRotation, Vector3.up ));
        }


        Vector3 xzVelocity = transform.forward * forwrardVelocity + transform.right * sidewardVelocity;

        rgBody.velocity = new Vector3(xzVelocity.x, rgBody.velocity.y, xzVelocity.z);


        // IsJumping //


        if (jumpUpForce > 0) {

            rgBody.AddForce((transform.up) * jumpUpForce, ForceMode.Impulse);
//            rgBody.velocity = new Vector3(rgBody.velocity.x, jumpUpVelocity, rgBody.velocity.z);
        }



	} // FixedUpdate() //


} // End Of Class //


