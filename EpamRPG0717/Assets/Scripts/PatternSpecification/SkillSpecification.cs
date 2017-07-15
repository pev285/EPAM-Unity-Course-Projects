
public class SkillSpecification<TSkill> : IGameObjectSpecification {

    TSkill a;

	public bool IsSatisfiedBy(UnityEngine.GameObject entity) {

        if (entity.GetComponent(typeof (TSkill)) == null) {
            return false;
        }

		return true;
	}

}
