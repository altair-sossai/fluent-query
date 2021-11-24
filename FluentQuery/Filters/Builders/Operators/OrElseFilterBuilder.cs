using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Builders.Abstractions;
using FluentQuery.Filters.Extensions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders.Operators
{
    public class OrElseFilterBuilder<T, TProperty> : AbstractFilterBuilder<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;

        public OrElseFilterBuilder(IFilterBuilder<T, TProperty> builder)
            : base(builder.Property)
        {
            _builder = builder;
        }

        public override ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Expression = _builder.Expression.OrElse(expression);

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}