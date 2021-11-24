﻿using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Operator;

namespace FluentQuery.Filters.Builders.Operators
{
    public class OrElseFilterBuilder<T, TProperty> : IFilterBuilder<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;

        public OrElseFilterBuilder(IFilterBuilder<T, TProperty> builder)
        {
            _builder = builder;
        }

        public Expression<Func<T, TProperty>> Property => _builder.Property;
        public IFilter<T> Filter => _builder.Filter;

        public ILogicalOperator<T, TProperty> Append(Expression<Func<T, bool>> expression)
        {
            Filter.Or(expression);

            return new LogicalOperator<T, TProperty>(this);
        }
    }
}