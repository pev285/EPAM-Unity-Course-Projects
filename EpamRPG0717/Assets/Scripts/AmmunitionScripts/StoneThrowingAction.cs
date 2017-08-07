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
    private Vector3 relativeSpellCastPosition = new Vector3(0, 2.5f, 1.8f);

    private GameObject stonePrefab;

    public StoneThrowingAction(GameObject stonePrefab) {
        this.stonePrefab = stonePrefab;
    }

	public override void Cast(GameObject caster, Quaternion castRotation) {

        GameObject newStone = GameObject.Instantiate(stonePrefab, 
                caster.transform.position + caster.transform.rotation * relativeSpellCastPosition,
                castRotation/*caster.transform.rotation*/, caster.transform);
    }


}
