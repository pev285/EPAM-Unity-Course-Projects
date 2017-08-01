using UnityEngine;

public class BowShotAction : AbstractSpellAction{

    public override string Name {
        get {
            return "BowShot";
        }
    }

    public override string Description {
        get {
            return "Shot from a bow";
        }
    }

    [SerializeField]
    private Vector3 relativeSpellCastPosition = new Vector3(0, 1.5f, 1.0f);

    private GameObject arrowPrefab;

//    private GameObject playerCamera;
//
//    private GameObject

    public BowShotAction(GameObject prefab /*, GameObject playerCamera*/) {
        this.arrowPrefab = prefab;
//        this.playerCamera = playerCamera;
    }

    public override void Cast(GameObject caster, GameObject casterCamera, GameObject targetingPoint) {
        Vector3 arrowPosition = caster.transform.position + caster.transform.rotation * relativeSpellCastPosition;
        Quaternion arrowRotation = caster.transform.rotation;


//        targetingPoint.transform.position = new Vector3(1f,1f,1f);
//        targetingPoint.transform.localScale = new Vector3(1f,1f,1f);

        RaycastHit raycastHit;
        Debug.Log ("from: " + casterCamera.transform.position + " direction: " +  (targetingPoint.transform.position - casterCamera.transform.position));
        if (Physics.Raycast(targetingPoint.transform.position, targetingPoint.transform.position - casterCamera.transform.position, out raycastHit)) {

//            Vector3 farPoint = raycastHit.point;
            Vector3 farPoint = raycastHit.collider.transform.position;
            Debug.Log("farPoint : " + farPoint);

            arrowRotation = Quaternion.FromToRotation(Vector3.forward, farPoint - arrowPosition);
            Debug.Log("arrowRotation: " + arrowRotation);
        } // If Raycast //

//        arrowRotation = playerCamera.transform.rotation;
//        Quaternion arrowRotation = caster.transform.rotation;   //Quaternion.AngleAxis(90, caster.transform.right);
        GameObject newArrow = GameObject.Instantiate(arrowPrefab, arrowPosition, arrowRotation);//, caster.transform);

    }

}
