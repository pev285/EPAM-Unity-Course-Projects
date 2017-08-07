using UnityEngine;

public class CastSpellCommand : AbstractCommand{

    GameObject caster;
    GameObject casterCamera;
    GameObject targetingPoint;

    AbstractSpell spell;

    public CastSpellCommand(GameObject caster, GameObject casterCamera, GameObject targetingPoint, AbstractSpell spell) {
        this.caster = caster;
        this.casterCamera = casterCamera;
        this.targetingPoint = targetingPoint;
        this.spell = spell;
    }

    public override void Execute() {
        spell.Cast(caster, caster.transform.rotation);
    }
}
