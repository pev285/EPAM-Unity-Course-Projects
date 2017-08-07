using UnityEngine;

public class CastCurrentSpellCommand : AbstractCommand {
    private EquippedSpells spells;
    private GameObject caster;
    private GameObject casterCamera;
    private GameObject targetingPoint;
//    private CharacterModel cmodel;

    public CastCurrentSpellCommand(GameObject caster, GameObject casterCamera, GameObject targetingPoint, EquippedSpells spells/*, CharacterModel cmodel*/) {
        this.caster = caster;
        this.casterCamera = casterCamera;
        this.targetingPoint = targetingPoint;
        this.spells = spells;
//        this.cmodel = cmodel;
    }

    public override void Execute() {

        /*
        Quaternion castRotation = caster.transform.rotation;

        castRotation = Quaternion.LookRotation(targetingPoint.transform.position, )

        RaycastHit raycastHit;
        if (Physics.Raycast(targetingPoint.transform.position, targetingPoint.transform.position - casterCamera.transform.position, out raycastHit))
        {
            Vector3 farPoint = raycastHit.point;

            //arrowRotation = Quaternion.FromToRotation(Vector3.forward, farPoint - arrowPosition);
//            arrowRotation = Quaternion.LookRotation(farPoint - arrowPosition, casterCamera.transform.up);
            castRotation = Quaternion.LookRotation(farPoint - arrowPosition, casterCamera.transform.up);

        } // If Raycast //
        else
        {
            Debug.Log("-== Not Raycast ==-");
        }
        */

        spells.GetCurrentSpell().Cast(caster, casterCamera.transform.rotation);// castRotation);

//        cmodel.SpecialAttack();
    }


}
