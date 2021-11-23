using System;
using System.Linq.Expressions;

namespace FluentQuery.Filters
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> Expression { get; set; }
    }

    public interface IFilter<T, TProperty> : IFilter<T>
    {
        public Expression<Func<T, TProperty>> Property { get; }
    }
}