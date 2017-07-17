using UnityEngine;

public static class GameObjectSpecificationExtensionMethods  {

    public static IGameObjectSpecification And(this IGameObjectSpecification spec1, IGameObjectSpecification spec2)
    {
        return new AndGameObjectSpecification(spec1, spec2);
    }

    public static IGameObjectSpecification Or (this IGameObjectSpecification spec1, IGameObjectSpecification spec2)
    {
        return new OrGameObjectSpecification(spec1, spec2);
    }

    public static IGameObjectSpecification Not(this IGameObjectSpecification spec)
    {
        return new NotGameObjectSpecification(spec);
    }
}
