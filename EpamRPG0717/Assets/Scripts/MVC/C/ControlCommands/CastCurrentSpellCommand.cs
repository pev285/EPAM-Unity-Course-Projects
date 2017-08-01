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


        spells.GetCurrentSpell().Cast(caster, casterCamera, targetingPoint);

//        cmodel.SpecialAttack();
    }


}
