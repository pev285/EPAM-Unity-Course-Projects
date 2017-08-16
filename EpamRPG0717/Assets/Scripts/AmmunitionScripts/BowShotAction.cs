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
    private Vector3 relativeSpellCastPosition = new Vector3(0, 1.5f, 2f);

    private GameObject arrowPrefab;

//    private GameObject playerCamera;
//
//    private GameObject

    public BowShotAction(GameObject prefab) {
        this.arrowPrefab = prefab;
    }

    public override void Cast(GameObject caster, Quaternion castRotation) {

        Vector3 arrowPosition = caster.transform.position + caster.transform.rotation * relativeSpellCastPosition;
        /*
        Quaternion arrowRotation = caster.transform.rotation;


        RaycastHit raycastHit;
        if (Physics.Raycast(targetingPoint.transform.position, targetingPoint.transform.position - casterCamera.transform.position, out raycastHit)) {


            Vector3 farPoint = raycastHit.point;

            //arrowRotation = Quaternion.FromToRotation(Vector3.forward, farPoint - arrowPosition);
            arrowRotation = Quaternion.LookRotation(farPoint - arrowPosition, casterCamera.transform.up);

        } // If Raycast //
        else
        {
            Debug.Log("-== Not Raycast ==-");
        }
        */
        GameObject newArrow = GameObject.Instantiate(arrowPrefab, arrowPosition, castRotation);//, caster.transform);

    }

}
