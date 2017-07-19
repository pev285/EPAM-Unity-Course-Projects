
public class SkillSpecification<TSkill> : IGameObjectSpecification {

//    TSkill skill;
    public override string ToString() {
        return (typeof (TSkill)).Name; //skill.name;
    }

	public bool IsSatisfiedBy(UnityEngine.GameObject entity) {

        if (entity.GetComponent(typeof (TSkill)) == null) {
            return false;
        }

		return true;
	}

}
