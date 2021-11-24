using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders
{
    public interface IFilterBuilder<T>
    {
        IFilter<T> Filter { get; }
    }

    public interface IFilterBuilder<T, TProperty> : IFilterBuilder<T>
    {
        Expression<Func<T, TProperty>> Property { get; }
        ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression);
    }
}