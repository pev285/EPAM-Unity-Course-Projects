using System;
using System.Text;
using UnityEngine;

public interface IGameObjectSpecification : ISpecification<GameObject> {
    //bool IsSatisfiedBy(TEntity entity);

//    string ToString();
}

internal class AndGameObjectSpecification : IGameObjectSpecification
{
    private readonly IGameObjectSpecification _spec1;
    private readonly IGameObjectSpecification _spec2;

    protected IGameObjectSpecification Spec1
    {
        get
        {
            return _spec1;
        }
    }

    protected IGameObjectSpecification Spec2
    {
        get
        {
            return _spec2;
        }
    }

    internal AndGameObjectSpecification(IGameObjectSpecification spec1, IGameObjectSpecification spec2)
    {
        if (spec1 == null)
            throw new ArgumentNullException("spec1");

        if (spec2 == null)
            throw new ArgumentNullException("spec2");

        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(GameObject candidate)
    {
        return Spec1.IsSatisfiedBy(candidate) && Spec2.IsSatisfiedBy(candidate);
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder("(");
        sb.Append(Spec1).Append(" AND ").Append(Spec2).Append(")");
        return sb.ToString();
    }

} // AndSpecification //

internal class OrGameObjectSpecification : IGameObjectSpecification
{
    private readonly IGameObjectSpecification _spec1;
    private readonly IGameObjectSpecification _spec2;

    protected IGameObjectSpecification Spec1
    {
        get
        {
            return _spec1;
        }
    }

    protected IGameObjectSpecification Spec2
    {
        get
        {
            return _spec2;
        }
    }

    internal OrGameObjectSpecification(IGameObjectSpecification spec1, IGameObjectSpecification spec2)
    {
        if (spec1 == null)
            throw new ArgumentNullException("spec1");

        if (spec2 == null)
            throw new ArgumentNullException("spec2");

        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(GameObject candidate)
    {
        return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder("(");
        sb.Append(Spec1).Append(" OR ").Append(Spec2).Append(")");
        return sb.ToString();
    }
} // OrSpecification //

internal class NotGameObjectSpecification : IGameObjectSpecification
{


    private readonly IGameObjectSpecification _wrapped;

    protected IGameObjectSpecification Wrapped
    {
        get
        {
            return _wrapped;
        }
    }

    internal NotGameObjectSpecification(IGameObjectSpecification spec)
    {
        if (spec == null)
        {
            throw new ArgumentNullException("spec");
        }

        _wrapped = spec;
    }

    public bool IsSatisfiedBy(GameObject candidate)
    {
        return !Wrapped.IsSatisfiedBy(candidate);
    }

    public override string ToString() {
        StringBuilder sb = new StringBuilder("NOT ");
        sb.Append(Wrapped);
        return sb.ToString();
    }

} // NotSpecification //

