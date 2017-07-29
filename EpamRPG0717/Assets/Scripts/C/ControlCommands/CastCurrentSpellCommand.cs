using UnityEngine;

public class CastCurrentSpellCommand : AbstractCommand {
    EquippedSpells spells;
    GameObject gameObject;
    private CharacterModel cmodel;

    public CastCurrentSpellCommand(GameObject go, EquippedSpells spells, CharacterModel cmodel) {
        this.gameObject = go;
        this.spells = spells;
        this.cmodel = cmodel;
    }

    public override void Execute() {
        spells.GetCurrentSpell().Cast(gameObject);

//        cmodel.SpecialAttack();
    }


}
