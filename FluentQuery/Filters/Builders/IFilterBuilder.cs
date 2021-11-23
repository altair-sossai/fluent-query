using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders
{
    public interface IFilterBuilder<T, TProperty> : IFilter<T>
    {
        Expression<Func<T, TProperty>> Property { get; }
        ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression);
    }
}