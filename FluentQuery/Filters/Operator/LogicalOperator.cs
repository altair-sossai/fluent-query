﻿using System;
using System.Linq.Expressions;
using FluentQuery.Filters.Builders;
using FluentQuery.Filters.Builders.Operators;

namespace FluentQuery.Filters.Operator
{
    public class LogicalOperator<T, TProperty> : ILogicalOperator<T, TProperty>
    {
        private readonly IFilterBuilder<T, TProperty> _builder;

        public LogicalOperator(IFilterBuilder<T, TProperty> builder)
        {
            _builder = builder;
        }

        public IFilterBuilder<T, TProperty> And()
        {
            return new AndAlsoFilterBuilder<T, TProperty>(_builder);
        }

        public IFilterBuilder<T, TNewProperty> And<TNewProperty>(Expression<Func<T, TNewProperty>> property)
        {
            return new AndAlsoFilterBuilder<T, TNewProperty>(property, _builder.Filter);
        }

        public IFilterBuilder<T, TProperty> Or()
        {
            return new OrElseFilterBuilder<T, TProperty>(_builder);
        }

        public IFilterBuilder<T, TNewProperty> Or<TNewProperty>(Expression<Func<T, TNewProperty>> property)
        {
            return new OrElseFilterBuilder<T, TNewProperty>(property, _builder.Filter);
        }
    }
}