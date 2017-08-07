using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour{

    private int jumpHash = Animator.StringToHash("Jump");
    private int runHash = Animator.StringToHash("Run");
    private int attackHash = Animator.StringToHash("Attack");
    private int walkHash = Animator.StringToHash("Walk");


    private Animator animator;



    private CharacterModel model;




/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////


// Use this for initialization
    void Start () {
        model = gameObject.GetComponent<CharacterModel>();

        animator = GetComponent<Animator>();

    }




    void Update() {
        float forwrardVelocity = model.GetForwardVelocity() * Time.deltaTime;
        float sidewardVelocity = model.GetSidewardVelocity() * Time.deltaTime;
//        float horizontalRotation = model.GetHorizontalRotation() * Time.deltaTime;
        float jumpUpForce = model.GetJumpForce();


        if (model.IsGrounded && !model.IsSpecialAttacking) {

            if (forwrardVelocity > 0) {
                animator.SetBool(runHash, true);
            } else {
                animator.SetBool(runHash, false);

                if (forwrardVelocity == 0 && sidewardVelocity == 0) {
                    animator.SetBool(walkHash, false);
                } else {
                    animator.SetBool(walkHash, true);
                }
            }
        }
        else {
//            animator.SetBool(runHash, false);
//            animator.SetBool(walkHash, false);
//
//
//            if (model.IsSpecialAttacking) {
//                animator.SetTrigger(attackHash);
//            }
//            else
//            {
//                animator.SetTrigger(jumpHash);
//            }
        }



    }
}