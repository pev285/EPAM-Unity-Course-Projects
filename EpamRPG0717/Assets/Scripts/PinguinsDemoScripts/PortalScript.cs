using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {

        Messaging.SetTopTextFor(5f, "You've just Entered a Portal");

        IGameObjectSpecification spec = new SkillSpecification<Magic>().Or(new SkillSpecification<Archery>());
//        IGameObjectSpecification spec = new ArcherySpecification();

        if (spec.IsSatisfiedBy(other.gameObject)) {
            Messaging.SetCenterTextFor(6f, "You have nesessary skills");
        } else {
            Messaging.SetCenterTextFor(6f, "You do not have nesessary skills");
            Messaging.SetBottomTextFor(6f, "You need: " + spec.ToString());
        }

    } // OnTriggerEnter() //

} // End Of Class //
