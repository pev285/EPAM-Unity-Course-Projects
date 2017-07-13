using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	//public Transform target;
	public float smoothTime = 0.1F;
    public float oneStep = 0.1f;

    private float xVelocity = 0.0F;

	private float targetX = 0.0f;

	private float boardWidthHalf = 1.25f;

	private static float speed = 2.5f;
	private Vector3 velocityLeft = new Vector3 (-speed, 0, 0);
	private Vector3 velocityRight = new Vector3 (speed, 0, 0);
	private Vector3 zeroVec3 = new Vector3 (0, 0, 0);

	public Rigidbody rb;

	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown ("escape")) {
			SceneManager.LoadScene ("Menu");
		}
/*
		if (Input.GetKeyDown ("left")) {
			rb.velocity = velocityLeft;
		} else if (Input.GetKeyDown ("right")) {
			rb.velocity = velocityRight;
		} else if (Input.GetKeyUp("left") || Input.GetKeyUp("right"))  {
			rb.velocity = zeroVec3;
		} 

//*/

//*
		float stime = smoothTime;

		if (Input.GetKey ("left")) {
            //targetX = transform.position.x - oneStep;
            targetX -= oneStep * Time.deltaTime * 20;
		} else if (Input.GetKey ("right")) {
			targetX += oneStep * Time.deltaTime * 20;
		}
		
		float newPosition = Mathf.SmoothDamp(transform.position.x, targetX, ref xVelocity, stime);
		if (newPosition > boardWidthHalf) {
			newPosition = boardWidthHalf;
			targetX = boardWidthHalf;
		} else if (newPosition < -boardWidthHalf) {
			newPosition = -boardWidthHalf;
			targetX = -boardWidthHalf;
		}
		//transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);
        rb.MovePosition(new Vector3(newPosition, transform.position.y, transform.position.z));
        //*/

    }
}
