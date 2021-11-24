using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders.Abstractions
{
    public abstract class AbstractFilterBuilder<T, TProperty> : IFilterBuilder<T, TProperty>
    {
        protected AbstractFilterBuilder(Expression<Func<T, TProperty>> property)
        {
            Property = property;
        }

        public Expression<Func<T, TProperty>> Property { get; }
        public Expression<Func<T, bool>> Expression { get; protected set; }

        public abstract ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression);
    }
}