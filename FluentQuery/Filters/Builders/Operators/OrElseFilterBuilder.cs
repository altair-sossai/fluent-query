using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders.Operators
{
    public class OrElseFilterBuilder<T, TProperty> : IFilterBuilder<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;
        private readonly IFilter<T> _filter;
        private readonly Expression<Func<T, TProperty>> _property;

        public OrElseFilterBuilder(IFilterBuilder<T, TProperty> builder)
        {
            _builder = builder;
        }

        public OrElseFilterBuilder(Expression<Func<T, TProperty>> property, IFilter<T> filter)
        {
            _property = property;
            _filter = filter;
        }

        public Expression<Func<T, TProperty>> Property => _property ?? _builder.Property;
        public IFilter<T> Filter => _filter ?? _builder.Filter;

        public ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Filter.Or(expression);

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}