using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zzzEnemyController : MonoBehaviour {

    [SerializeField]
    private float critiacalDistanceSqr = 225f;

    public float TurnDirection = 0;
    public float MoveDirection = 0;

    public bool MovingForward()
    {
        return MoveDirection > 0;
    }

    public bool MovingBackward()
    {
        return MoveDirection < 0;
    }

    public bool TurnLeft()
    {
        return TurnDirection < 0;
    }
    public bool TurnRight()
    {
        return TurnDirection > 0;
    }


    public bool NearEnough(GameObject g)
    {
        return (gameObject.transform.position - g.transform.position).sqrMagnitude < critiacalDistanceSqr;
    }
    

    public Vector3 FindDirection(GameObject g)
    {
        Vector3 directionVector = (g.transform.position - gameObject.transform.position).normalized;

        MoveDirection = Vector3.Dot(gameObject.transform.forward, directionVector);
        TurnDirection = gameObject.transform.forward.x * directionVector.z - gameObject.transform.forward.z * directionVector.x;

        return directionVector;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
