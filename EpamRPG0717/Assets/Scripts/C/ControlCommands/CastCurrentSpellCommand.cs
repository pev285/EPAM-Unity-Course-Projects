using UnityEngine;

public class CastCurrentSpellCommand : AbstractCommand {
    public override void Execute() {
        spells.GetCurrentSpell().Cast(gameObject);
    }

    EquippedSpells spells;
    GameObject gameObject;

    public CastCurrentSpellCommand(GameObject go, EquippedSpells spells) {
        this.gameObject = go;
        this.spells = spells;
    }
}
