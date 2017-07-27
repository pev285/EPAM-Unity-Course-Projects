using UnityEngine;

public class CastSpellCommand : AbstractCommand{

    GameObject caster;
    AbstractSpell spell;

    public CastSpellCommand(GameObject caster, AbstractSpell spell) {
        this.caster = caster;
        this.spell = spell;
    }

    public override void Execute() {
        spell.Cast(caster);
    }
}
