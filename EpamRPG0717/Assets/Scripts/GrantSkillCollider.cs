using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrantSkillCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) {

        other.gameObject.AddComponent<Magic>();

        Messaging.SetCenterTextFor(5f, "Now you have Magic Skill!");
	}
}
