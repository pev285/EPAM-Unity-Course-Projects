using System;

public interface ISpecification<TEntity>
{
    bool IsSatisfiedBy(TEntity entity);
}
 
internal class AndSpecification<TEntity> : ISpecification<TEntity>
{
    private readonly ISpecification<TEntity> _spec1;
    private readonly ISpecification<TEntity> _spec2;

    protected ISpecification<TEntity> Spec1
    {
        get
        {
            return _spec1;
        }
    }

    protected ISpecification<TEntity> Spec2
    {
        get
        {
            return _spec2;
        }
    }

    internal AndSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
    {
        if (spec1 == null)
            throw new ArgumentNullException("spec1");

        if (spec2 == null)
            throw new ArgumentNullException("spec2");

        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(TEntity candidate)
    {
        return Spec1.IsSatisfiedBy(candidate) && Spec2.IsSatisfiedBy(candidate);
    }
} // AndSpecification //

internal class OrSpecification<TEntity> : ISpecification<TEntity>
{
    private readonly ISpecification<TEntity> _spec1;
    private readonly ISpecification<TEntity> _spec2;

    protected ISpecification<TEntity> Spec1
    {
        get
        {
            return _spec1;
        }
    }

    protected ISpecification<TEntity> Spec2
    {
        get
        {
            return _spec2;
        }
    }

    internal OrSpecification(ISpecification<TEntity> spec1, ISpecification<TEntity> spec2)
    {
        if (spec1 == null)
            throw new ArgumentNullException("spec1");

        if (spec2 == null)
            throw new ArgumentNullException("spec2");

        _spec1 = spec1;
        _spec2 = spec2;
    }

    public bool IsSatisfiedBy(TEntity candidate)
    {
        return Spec1.IsSatisfiedBy(candidate) || Spec2.IsSatisfiedBy(candidate);
    }
} // OrSpecification //

internal class NotSpecification<TEntity> : ISpecification<TEntity>
{
    private readonly ISpecification<TEntity> _wrapped;

    protected ISpecification<TEntity> Wrapped
    {
        get
        {
            return _wrapped;
        }
    }

    internal NotSpecification(ISpecification<TEntity> spec)
    {
        if (spec == null)
        {
            throw new ArgumentNullException("spec");
        }

        _wrapped = spec;
    }

    public bool IsSatisfiedBy(TEntity candidate)
    {
        return !Wrapped.IsSatisfiedBy(candidate);
    }
} // NotSpecification //

