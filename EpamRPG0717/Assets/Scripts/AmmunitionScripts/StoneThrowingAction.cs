using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneThrowingAction : AbstractSpellAction {
	public override string Name {
		get {
			return "StoneThrowing";
		}
	}

	public override string Description {
		get {
			return "One throws a stone";
		}
	}

    [SerializeField]
    private Vector3 relativeSpellCastPosition = new Vector3(0, 1.5f, 0.8f);
	[SerializeField]
    private float stoneThrowingForce = 300f;
    [SerializeField]
    private float flightTime = 3.0f;

    private GameObject stonePrefab;

    public StoneThrowingAction(GameObject stonePrefab) {
        this.stonePrefab = stonePrefab;
    }

	public override void Cast(UnityEngine.GameObject caster) {
		GameObject newStone = GameObject.Instantiate(stonePrefab, caster.transform.position + caster.transform.rotation * relativeSpellCastPosition,
                caster.transform.rotation, caster.transform);


        Rigidbody stoneRigidBody = newStone.GetComponent<Rigidbody>();
//        stoneRigidBody.velocity = (caster.transform.forward * bulletInitialVelocity);
		stoneRigidBody.AddForce(caster.transform.forward * stoneThrowingForce);


        Timer t = new Timer(newStone, delegate  {
            GameObject.Destroy(newStone);
        }, flightTime);
    }


}
