using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders.Operators
{
    public class AndAlsoFilterBuilder<T, TProperty> : IFilterBuilder<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;

        public AndAlsoFilterBuilder(IFilterBuilder<T, TProperty> builder)
        {
            _builder = builder;
        }

        public Expression<Func<T, TProperty>> Property => _builder.Property;
        public IFilter<T> Filter => _builder.Filter;

        public ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Filter.And(expression);

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}