using System;
using System.Linq.Expressions;

namespace FluentQuery.Filters
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> Expression { get; }
    }
}