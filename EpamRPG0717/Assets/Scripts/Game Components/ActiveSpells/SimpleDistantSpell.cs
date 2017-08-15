using UnityEngine;

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

    private float lastTime = 0;

    public override void Cast(GameObject caster, Quaternion castRotation) {

        if (Time.time - lastTime > action.CoolingTime)
        {
            action.Cast(caster, castRotation);

            lastTime = Time.time;

        }
    }
}

