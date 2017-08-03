
using UnityEngine;

public abstract class AbstractSpell : MonoBehaviour, ICastable, INameAndDescription{

    public abstract void Cast (GameObject caster, GameObject casterCamera, GameObject targetingPoint);

    public abstract string Description { get; }

    public abstract string Name { get; }

    public override string ToString() {
        return Name;
    }

}
