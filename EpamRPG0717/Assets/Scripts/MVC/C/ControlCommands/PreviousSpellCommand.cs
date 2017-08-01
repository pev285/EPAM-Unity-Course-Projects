public class PreviousSpellCommand : AbstractCommand{

    EquippedSpells spells;

    public PreviousSpellCommand(EquippedSpells spells) {
        this.spells = spells;
    }

    public override void Execute() {
        spells.ShiftBackward();
    }

}
