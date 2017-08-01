public class NextSpellCommand : AbstractCommand{

    EquippedSpells spells;

    public NextSpellCommand(EquippedSpells spells) {
        this.spells = spells;
    }

    public override void Execute() {
        spells.ShiftForward();
    }

}
