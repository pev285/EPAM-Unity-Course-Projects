using System.Text;

public class ComplexSpell : AbstractSpell {

    private string name = "";
    private string description = "";


    public override string Name {
        get {
            return name;
        }
    }

    public override string Description {
        get {
            return description;
        }
    }

    private AbstractSpellAction[] spellActions;

    public ComplexSpell(AbstractSpellAction[] actions) {
        this.spellActions = actions;

        StringBuilder sbNames = new StringBuilder();
        StringBuilder sbDescrs =  new StringBuilder();

        if (actions.Length > 0) {

            foreach (AbstractSpellAction action in actions) {
                sbNames.Append(action.Name).Append(", ");
                sbDescrs.Append(action.Name).Append(": ").Append(action.Description).Append("; ");
                name = sbNames.ToString(0, sbNames.Length-2);
                description = sbDescrs.ToString(0, sbDescrs.Length-2);
            }
        }

    }

    public override void Cast(UnityEngine.GameObject caster) {
        foreach (AbstractSpellAction action in spellActions) {
            action.Cast(gameObject);
        }
    }
}
