using UnityEngine;

public abstract class AbstractSpellAction : ICastable, INameAndDescription {

    public abstract string Description { get; }

    public abstract string Name { get; }

    public abstract void Cast(GameObject caster, Quaternion castRotation);


    protected float coolingTime = 2;
    public float CoolingTime
    {
        get
        {
            return coolingTime;
        }
    }

}
