
public class ArcherySpecification : IGameObjectSpecification {

	public bool IsSatisfiedBy(UnityEngine.GameObject entity) {

        if (entity.GetComponent<Archery>() == null) {
            return false;
        }

		return true;
	}

}
