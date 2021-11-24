using System;
using System.Linq.Expressions;

namespace FluentQuery.Filters
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> Expression { get; }
        IFilter<T> And(Expression<Func<T, bool>> expression);
        IFilter<T> Or(Expression<Func<T, bool>> expression);
    }
}