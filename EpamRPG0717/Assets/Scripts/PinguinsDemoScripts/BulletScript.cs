using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) {
//        print("collision");
        Health h = other.gameObject.GetComponent<Health>();
        if (h != null) {
            h.ChangeHealthBy(-15);
        }

//        Destroy(other.gameObject);
        Destroy(gameObject);
	}


} // BulletScript //
