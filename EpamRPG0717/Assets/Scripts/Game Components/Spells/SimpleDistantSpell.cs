public class SimpleDistantSpell : AbstractSpell{

    public override string Name {
        get {
            return action.Name;
        }
    }

    public override string Description {
        get {
            return action.Description;
        }
    }

    private AbstractSpellAction action;

    public SimpleDistantSpell(AbstractSpellAction action) {
        this.action = action;
    }

    public override void Cast(UnityEngine.GameObject caster) {
        action.Cast(caster);
    }
}

