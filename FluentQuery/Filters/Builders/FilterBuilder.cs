using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders
{
    public class FilterBuilder<T, TProperty> : IFilterBuilder<T, TProperty>
    {
        public FilterBuilder(Expression<Func<T, TProperty>> property)
        {
            Property = property;
        }

        public Expression<Func<T, TProperty>> Property { get; }
        public IFilter<T> Filter { get; private set; }

        public ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Filter = new Filter<T>(expression);

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}