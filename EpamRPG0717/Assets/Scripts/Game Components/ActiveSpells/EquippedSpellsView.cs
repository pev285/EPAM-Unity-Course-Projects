using System.Text;

public class EquippedSpellsView {

    public static void Redraw(EquippedSpells spells) {
        StringBuilder sb = new StringBuilder();
        sb.Append("Current Spell: ");
        sb.Append(spells.GetCurrentSpell().Name);//.Append(": ").Append(spells.GetCurrentSpell().Description);
        Messaging.SetTechInfoText(sb.ToString());

    }
}

