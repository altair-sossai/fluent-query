using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Builders.Abstractions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders
{
    public class FilterBuilder<T, TProperty> : AbstractFilterBuilder<T, TProperty>
    {
        public FilterBuilder(Expression<Func<T, TProperty>> property)
            : base(property)
        {
        }

        public override ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Expression = expression;

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}