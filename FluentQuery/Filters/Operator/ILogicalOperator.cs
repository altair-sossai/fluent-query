using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Builders;

namespace FluentQuery.Filters.Operator
{
    public interface ILogicalOperator<T, TProperty>
    {
        IFilterBuilder<T, TProperty> And();
        IFilterBuilder<T, TNewProperty> And<TNewProperty>(Expression<Func<T, TNewProperty>> property);
        IFilterBuilder<T, TProperty> Or();
        IFilterBuilder<T, TNewProperty> Or<TNewProperty>(Expression<Func<T, TNewProperty>> property);
    }
}