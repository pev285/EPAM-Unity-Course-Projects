using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public GameObject player;

//	public Vector3 force = new Vector3(0f, 0f, 100.0f);

	private static float speed = 2.5f;
	private Vector3 velocityLeft = new Vector3 (-speed, 0, 0);
	private Vector3 velocityRight = new Vector3 (speed, 0, 0);

	private bool playing = false;

	private Rigidbody rb;



	// Use this for initialization
	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {

		if (!playing) {
            if (Input.GetKey("space"))
            {
                playing = true;

                Vector3 vel = rb.velocity;
                //print("rbvel=" + vel);
                vel = player.GetComponent<Rigidbody>().velocity;
                //print("playerVel=" + vel);

                //rb.velocity = new Vector3(vel.x, vel.y, vel.z + speed);

                rb.velocity = new Vector3(vel.x, vel.y, Mathf.Sqrt(speed * speed - 0.25f * vel.x * vel.x));

                //rb.AddForce (new Vector3(0f, 0f, 100.0f));
            }
            else
            {
                Vector3 targetPosition = transform.position;
                targetPosition.x = player.transform.position.x;
                rb.MovePosition(targetPosition);
            }



            /*
            else if (Input.GetKeyDown ("left")) {
				rb.velocity = velocityLeft;
			} else if (Input.GetKeyDown ("right")) {
				rb.velocity = velocityRight;
			} else if (Input.GetKeyUp ("left") || Input.GetKeyUp ("right")) {
				rb.velocity = Vector3.zero;
			} */
            
		} else // If ball is playing //
        {
            Vector3 vel = rb.velocity;
            float velnorm = Mathf.Sqrt(vel.x * vel.x + vel.y * vel.y + vel.z * vel.z);

            float minCompSpeed = 0.1f * speed;

            //print("moving vel=" + vel + ", velnorm=" + velnorm);

            //*
            if (velnorm < speed && velnorm > 0)
            {

                //print("vn=" + velnorm + ", speed=" + speed);

                float mu = speed / velnorm;
                Vector3 newVelocity = new Vector3(vel.x * mu, vel.y * mu, vel.z * mu);
                //print("mu=" + mu + ", newVel=" + newVelocity);

                rb.velocity = newVelocity;
            } /* else if (vel.z < minCompSpeed) {

                if (vel.z != 0)
                {
                    float mu = minCompSpeed / Mathf.Abs(vel.z);
                    rb.velocity = new Vector3(vel.x, vel.y, vel.z * mu);
                } else
                {
                    if (transform.position.z > 0)
                    {
                        rb.velocity = new Vector3(vel.x, vel.y, -minCompSpeed);
                    } else
                    {
                        rb.velocity = new Vector3(vel.x, vel.y, minCompSpeed);
                    }


                }

            }//*/

        }




	}
}
