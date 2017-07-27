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
	void Update () {
		
	}
}
